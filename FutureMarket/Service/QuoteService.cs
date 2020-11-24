using FoodYeah.Commons;
using FoodYeah.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service
{
    public interface QuoteService
    {
        void Create(CreateQuoteDto model);
        void Remove(int id);
        QuoteDto GetAllQuotes();
        void PayQuote(int id,decimal amount);
        List<QuoteDto> GetByQuoteDetailId(int id);
        List<QuoteDto> UpdateInterest(int id);
    }
}
