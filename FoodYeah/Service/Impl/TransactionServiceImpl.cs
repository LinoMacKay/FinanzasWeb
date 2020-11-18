using AutoMapper;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Service.Impl
{
    public class TransactionServiceImpl : TransactionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TransactionServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public TransactionDto Create(TransactionCreateDto model)
        {
            var entry = new Transaction {
                Customer = _context.Customers.Single(x => x.CustomerId == model.CustomerId),
                CustomerId = model.CustomerId,
                Status = model.Status,
                Description = model.Description
            };
            _context.Transactions.Add(entry);
            _context.SaveChanges();
            return _mapper.Map<TransactionDto>(entry);
        }

        public DataCollection<TransactionDto> GetAll(int page, int take)
        {
            throw new NotImplementedException();
        }

        public TransactionDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
