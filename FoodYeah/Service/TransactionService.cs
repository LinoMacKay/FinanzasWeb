using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service
{
    public interface TransactionService
    {
        TransactionDto Create(TransactionCreateDto model);
        DataCollection<TransactionDto> GetAll(int page, int take);
        TransactionDto GetById(int id);
    }
}
