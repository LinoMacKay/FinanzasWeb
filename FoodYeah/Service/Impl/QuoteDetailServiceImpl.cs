using AutoMapper;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service.Impl
{
    public class QuoteDetailServiceImpl : QuoteDetailService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly TransactionService _transactionService;
        private static int id;

        public QuoteDetailServiceImpl(ApplicationDbContext context,
          IMapper mapper, TransactionService transactionService)
        {
            _context = context;
            _mapper = mapper;
            _transactionService = transactionService;
        }

        public QuoteDetailsDto Create(CreateQuoteDetailsDto model,decimal totalPrice)
        {
            
            decimal tasa = (_context.LOCs.Single(x => x.LOCId == model.LocId).TEA / 100);
            double numerobase = 1 + Decimal.ToDouble(tasa);
            decimal potencia = Convert.ToDecimal(model.Frecuency) / 360m;

            decimal tasaConvertida = Convert.ToDecimal(Math.Pow(numerobase, Decimal.ToDouble(potencia)) - 1);
            
            decimal e = Convert.ToDecimal(Math.Pow((1 + Decimal.ToDouble(tasaConvertida)), model.NumberQuotes));
            decimal quote = totalPrice * ((tasaConvertida * e)/(e - 1));
            List<decimal> cuotas = new List<decimal>();
            decimal Total = 0m;
            for(int i = 0; i < model.NumberQuotes; i++)
            {
                quote = Math.Round(quote, 2);
                cuotas.Add(quote);
                Total += quote;
                
            }

            var entry = new QuoteDetail
            {
                NumberQuotes = model.NumberQuotes,
                Frecuency = model.Frecuency,
                PaymentType = model.PaymentType,
                InterestRate = tasa,
                LocId = model.LocId,
                Quotes = cuotas,
                Debt = cuotas[0],
                LastTotal = Total
            };
            
            _context.QuoteDetails.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<QuoteDetailsDto>(entry);

        }

        public void Remove(int id)
        {
            var target = _context.QuoteDetails.Single(x => x.QuoteDetailsId == id);
            _context.QuoteDetails.Remove(target);
            _context.SaveChanges();

        }
        public DataCollection<QuoteDetailsDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<QuoteDetailsDto>>(
                 _context.QuoteDetails.OrderByDescending(x => x.QuoteDetailsId)
                               .Include(x => x.Loc)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public QuoteDetailsDto GetById(int id)
        {
            return _mapper.Map<QuoteDetailsDto>(
                _context.QuoteDetails.Single(x => x.QuoteDetailsId == id)
           );
        }

        public void Update(int id, UpdateQuoteDetailsDto model)
        {
            throw new NotImplementedException();
        }

        public void PayQuote(int quoteDetailId)
        {
            var qd = _context.QuoteDetails.Single(x => x.QuoteDetailsId == quoteDetailId);
            var loc = _context.LOCs.Single(x => x.LOCId == qd.LocId);
            if(qd.Quotes.Count > 0)
            {
                if(loc.AvalibleLineOfCredit >= qd.Quotes.ElementAt(0))
                {
                    loc.AvalibleLineOfCredit -= qd.Quotes.ElementAt(0);
                    _transactionService.Create(new TransactionCreateDto
                    {
                        CustomerId = loc.CustomerId,
                        Status = "Pagado " + qd.Quotes.ElementAt(0).ToString(),
                        Description = "Cuota " + (qd.NumberQuotes - qd.Quotes.Count + 1).ToString() +
                        " del conjunto de cuotas cuyo ID es " + qd.QuoteDetailsId.ToString()
                    });
                    qd.Quotes.RemoveAt(0);
                }
                else { return; }
            }
            else { return; }
        }
    }
}
