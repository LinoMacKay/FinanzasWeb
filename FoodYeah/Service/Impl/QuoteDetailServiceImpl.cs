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
using static FoodYeah.Commons.Enums;

namespace FoodYeah.Service.Impl
{
    public class QuoteDetailServiceImpl : QuoteDetailService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly TransactionService _transactionService;

        public QuoteDetailServiceImpl(ApplicationDbContext context,
          IMapper mapper, TransactionService transactionService)
        {
            _context = context;
            _mapper = mapper;
            _transactionService = transactionService;
        }
        public decimal ConvertToTea(Enums.TypeRate type, decimal rate)
        {
            if(type == (TypeRate)2)
            {
                decimal TNA = Convert.ToDecimal((Math.Pow(Decimal.ToDouble( 1+(rate / 360)), 360)) - 1);
                return TNA;
            }
            if (type == (TypeRate)3)
            {
                return rate;
            }

                return rate;
            
        }
        public QuoteDetailsDto Create(CreateQuoteDetailsDto model,decimal totalPrice)
        {
            
            decimal tasa = (_context.LOCs.Single(x => x.LOCId == model.LocId).Rate / 100);
            var TypeRate = (_context.LOCs.Single(x => x.LOCId == model.LocId).TypeRate);
            decimal newTasa = ConvertToTea(TypeRate, tasa);

            double numerobase = 1 + Decimal.ToDouble(newTasa);
            decimal potencia = Convert.ToDecimal(model.Frecuency) / 360m;

            decimal tasaConvertida = Convert.ToDecimal(Math.Pow(numerobase, Decimal.ToDouble(potencia)) - 1);
            
            decimal e = Convert.ToDecimal(Math.Pow((1 + Decimal.ToDouble(tasaConvertida)), model.NumberQuotes));
            decimal quote = totalPrice * ((tasaConvertida * e)/(e - 1));
            List<decimal> cuotas = new List<decimal>();
            decimal Total = 0m;
            for(int i = 0; i < model.NumberQuotes; i++)
            {
                quote = Math.Round(quote, 1);
                cuotas.Add(quote);
                Total += quote;
                
            }


            var primerDiaDePago = DateTime.Today;
            var entry = new QuoteDetail
            {
                NumberQuotes = model.NumberQuotes,
                Frecuency = model.Frecuency,
                PaymentType = model.PaymentType,
                InterestRate = tasa,
                LocId = model.LocId,
                Quotes = cuotas,
                Debt = cuotas[0],
                LastTotal = Total,
                FirstPaidDay = primerDiaDePago,
                LastPaidDay = primerDiaDePago.AddDays(model.Frecuency)
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

        public void PayQuote(decimal amount, int quoteDetailId)
        {
            var qd = _context.QuoteDetails.Single(x => x.QuoteDetailsId == quoteDetailId);
            var DeudaTotal = 0m;
            var loc = _context.LOCs.Single(x => x.LOCId == qd.LocId);
            if(qd.Quotes.Count > 0)
            {
                if(amount == qd.Quotes.ElementAt(0))
                {
                    
                    _transactionService.Create(new TransactionCreateDto
                    {
                        CustomerId = loc.CustomerId,
                        Status = "Accepted ",
                        Description = "Se ha pagado la cuota total con el valor de " + qd.Quotes.ElementAt(0).ToString()
                    });
                    qd.Quotes.RemoveAt(0);
                }
                else if(amount > qd.Quotes.ElementAt(0)) {
                    
                        foreach (decimal quote in qd.Quotes.ToList())
                        {
                        
                            if (amount > quote)
                            {
                                _transactionService.Create(new TransactionCreateDto
                                {
                                    CustomerId = loc.CustomerId,
                                    Status = "Accepted ",
                                    Description = "Se ha pagado la cuota total con el valor de " + quote.ToString()
                                });
                                amount -= quote;
                                qd.Quotes.RemoveAt(0);

                            }
                            else
                            {
                                _transactionService.Create(new TransactionCreateDto
                                {
                                    CustomerId = loc.CustomerId,
                                    Status = "Accepted ",
                                    Description = "Se ha pagado parcialmente la cuota  el valor de " + amount.ToString()
                                });
                                var cuota = qd.Quotes.ElementAt(0);
                                qd.Quotes.RemoveAt(0);
                                cuota -= amount;
                                qd.Quotes.Insert(0, cuota);
                                qd.LastTotal -= amount;
                                amount = 0;
                            }
                        if (amount == 0) break;
                    }
                        
                    }
                else if(amount < qd.Quotes.ElementAt(0))
                {
                    _transactionService.Create(new TransactionCreateDto
                    {
                        CustomerId = loc.CustomerId,
                        Status = "Accepted ",
                        Description = "Se ha pagado parcialmente la cuota  el valor de " + amount.ToString()
                    });

                    var cuota = qd.Quotes.ElementAt(0);
                    qd.Quotes.RemoveAt(0);
                    cuota -= amount;
                    qd.Quotes.Insert(0, cuota);
                }
                if (qd.Quotes.Count == 0)
                {
                    _context.QuoteDetails.Remove(qd);
                }


                else {
                    qd.Debt = qd.Quotes.ElementAt(0);
                    foreach (decimal quote in qd.Quotes.ToList())
                        DeudaTotal += quote;
                    qd.LastTotal = DeudaTotal;
                }
                _context.SaveChanges();
            }
            else { return; }
        }

       
    }
}
