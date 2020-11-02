using AutoMapper;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service.Impl
{
    public class QuoteDetailServiceImpl : QuoteDetail
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuoteDetailServiceImpl(ApplicationDbContext context,
          IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public QuoteDetailsDto Create(CreateQuoteDetailsDto model)
        {
            var entry = new QuoteDetail
            {
                NumberQuotes = model.NumberQuotes,
                Frecuency = model.Frecuency,
                PaymentType = model.PaymentType,
                InterestRate = model.InterestRate,
                LastTotal = model.LastTotal

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

        public void Update(int id, UpdateQuoteDetailsDto model)
        {
            throw new NotImplementedException();
        }
    }
}
