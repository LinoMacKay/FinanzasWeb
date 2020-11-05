using FoodYeah.Commons;
using FoodYeah.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service
{
    public interface QuoteDetailService
    {
        QuoteDetailsDto Create(CreateQuoteDetailsDto model, int orderId);
        void Update(int id, UpdateQuoteDetailsDto model);
        void Remove(int id);
        DataCollection<QuoteDetailsDto> GetAll(int page, int take);
        QuoteDetailsDto GetById(int id);
        void PayQuote(int quoteDetailId);
    }
}
