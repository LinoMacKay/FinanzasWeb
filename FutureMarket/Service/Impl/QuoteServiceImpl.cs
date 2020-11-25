using AutoMapper;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service.Impl
{
    public class QuoteServiceImpl : QuoteService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly TransactionService _transactionService;
        private readonly QuoteDetailService _quoteDetailService;
        

        public QuoteServiceImpl(ApplicationDbContext context,
            IMapper mapper,TransactionService transactionService, QuoteDetailService quoteDetailService)
        {
            _context = context;
            _mapper = mapper;
            _transactionService = transactionService;
            _quoteDetailService = quoteDetailService;
        }

        public decimal CurrencyConverterDollars(decimal price)
        {

            var client = new RestClient("https://api.currencyfreaks.com/latest?apikey=da06e3bb1f1d4da08b8e5cde85590ed8&symbols=PEN,USD'");

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            var values = JsonConvert.DeserializeObject<CurrencyDto>(response.Content);
            decimal change = Convert.ToDecimal(values.Rates.PEN);

            decimal valuechange = price / change;

            return valuechange;
        }
        public decimal CurrencyConverterPen(decimal price)
        {

            var client = new RestClient("https://api.currencyfreaks.com/latest?apikey=da06e3bb1f1d4da08b8e5cde85590ed8&symbols=PEN,USD'");

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            var values = JsonConvert.DeserializeObject<CurrencyDto>(response.Content);
            decimal change = Convert.ToDecimal(values.Rates.PEN);

            decimal valuechange = price * change;

            return valuechange;
        }
        public void Create(CreateQuoteDto model)
        {
            var entry = new Quote
            {
                Value = model.Value,
                FirstPaidDay = model.FirstPaidDay,
                LastPaidDay = model.LastPaidDay,
                Interest = model.Interest
            };

            _context.Quotes.Add(entry);
            _context.SaveChanges();
                
        }

        public QuoteDto GetAllQuotes()
        {
            throw new NotImplementedException();
        }

        public List<QuoteDto> GetByQuoteDetailId(int id)
        {
            return _mapper.Map<List<QuoteDto>>(
                _context.Quotes.Where(x =>x.QuoteDetailsId == id));
        }

       

        public void PayQuote(int id,decimal amount)
        {
            var quote = _context.Quotes.Single(x => x.QuoteId == id);
            var quoteDetail = _context.QuoteDetails.Single(x=>x.QuoteDetailsId == quote.QuoteDetailsId);
            var Loc = _context.LOCs.Single(x => x.LOCId == quoteDetail.LocId);

            if (quoteDetail.Currency != "Soles")
            {
                var newamount = CurrencyConverterPen(amount);
                Loc.AvalibleLineOfCredit += newamount;

            }
            else
            {
                Loc.AvalibleLineOfCredit += amount;
            }
            var client = _context.Customers.Single(x => x.CustomerId == Loc.CustomerId);
            if( amount < quote.Value + quote.Interest)
            {
                quote.Value -= amount;
                _transactionService.Create(new TransactionCreateDto
                { CustomerId = client.CustomerId, Description = "Se ha pagado la cuota parcialmente en valor de: " +amount, Status = "Accepted" });
                
            }
            else if(quote.Interest + quote.Value == amount) 
            {
                quote.Value -= amount;
                _transactionService.Create(new TransactionCreateDto
                { CustomerId = client.CustomerId, Description = "Se ha pagado la cuota totalmente en valor de: " + amount, Status = "Accepted" });

                Remove(id);
            }
            decimal DeudaTotal = 0;

        

            List<Quote> cuotas = _context.Quotes.Where(x => x.QuoteDetailsId == quoteDetail.QuoteDetailsId).ToList();


            quoteDetail.Debt = cuotas.ElementAt(0).Value;
            foreach (Quote cuota in cuotas)
                DeudaTotal += cuota.Value;
            quoteDetail.LastTotal = DeudaTotal;

            if(cuotas.Count == 0)
            {
                _quoteDetailService.Remove(quoteDetail.QuoteDetailsId);
            }

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var entry = _context.Quotes.Single(x => x.QuoteId == id);
            _context.Remove(entry);
            _context.SaveChanges();
        }

        public List<QuoteDto> UpdateInterest(int id)
        {
            var debts = _context.Quotes.Where(x => x.QuoteDetailsId == id);
            var quotedetail = _context.QuoteDetails.Single(x => x.QuoteDetailsId == id);
            DateTime fechaHoy = DateTime.Now;

            foreach (Quote debt in debts)
            {
                decimal Diferencia = Convert.ToDecimal(Math.Round((fechaHoy - debt.LastPaidDay).TotalDays));
                if (Diferencia > 0)
                {
                    var tasa = quotedetail.InterestRate;
                    var valor = debt.Value;
                    var diastasa = quotedetail.Frecuency;
                    
                    decimal interestasa = Convert.ToDecimal((Math.Pow(Decimal.ToDouble(1+tasa), Decimal.ToDouble(Diferencia) / diastasa))) -1;
                    decimal interes = debt.Value * interestasa;
                    
                    

                    debt.Interest = Math.Round(interes,1, MidpointRounding.AwayFromZero);

                }
                else
                {
                    debt.Interest = 0;
                }
            }
            _context.SaveChanges();

            return _mapper.Map<List<QuoteDto>>(
                _context.Quotes.Where(x => x.QuoteDetailsId == id));
        }
    }
}
