using FoodYeah.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service
{
    public interface QuoteDetailService
    {
        QuoteDetailsDto Create(CreateQuoteDetailsDto model);
        void Update(int id, UpdateQuoteDetailsDto model);
        void Remove(int id);
    }
}
