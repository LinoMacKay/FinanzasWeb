using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using System;
using FoodYeah.Model.Identity;
using System.Collections.Generic;
using FoodYeah.Migrations;
using System.Security.Cryptography.X509Certificates;

namespace FoodYeah.Service
{
    public class CustomerServiceImpl : CustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;

        public CustomerServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }


        public CustomerDto Create(CustomerCreateDto model)
        {  
            Customer_Category CustomerCategory = _context.Customer_Categories
            .Single(x=> x.Customer_CategoryId == model.Customer_CategoryId);

            ApplicationUser user = _context.Users.Single(x => x.Email == model.Email);

            var entry = new Customer
            {
                CustomerName = model.CustomerName,
                CustomerLastName = model.CustomerLastName,
                CustomerAge = model.CustomerAge,
                Customer_CategoryId = model.Customer_CategoryId,
                Customer_Category = CustomerCategory,
                Email = user.Email,
                UserEmail = user.Email,
                User = user,
                CustomerId = id++
            };
      
            _context.Customers.Add(entry);
            _context.SaveChanges();
            
            return _mapper.Map<CustomerDto>(entry);
        }


        public void Remove(int id)
        {
            _context.Remove(new Customer
            {
                CustomerId = id
            });

            _context.SaveChanges();
        }


        public void Update(int id, CustomerUpdateDto model)
        {
            var entry = _context.Customers.Single(x => x.CustomerId == id);
            
            entry.CustomerName = model.CustomerName;
            entry.CustomerAge = model.CustomerAge;
            entry.Customer_CategoryId = model.Customer_CategoryId;
            
            _context.SaveChanges();
        }

        public DataCollection<CustomerDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CustomerDto>>(
                 _context.Customers
                              .Include(x => x.Orders)
                              .Include(x => x.Cards)
                              .Include(x => x.Customer_Category)
                              .Include(x=>x.Transactions)
                              .OrderByDescending(x => x.CustomerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public DataCollection<CustomerSimpleDto> GetAllSimple(int page, int take)
        {
            return _mapper.Map<DataCollection<CustomerSimpleDto>>(
                 _context.Customers
                              .OrderByDescending(x => x.CustomerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public CustomerDto GetById(int id)
        {
            return _mapper.Map<CustomerDto>(
                 _context.Customers
                 .Include(x => x.Orders)
                 .Include(x => x.Cards)
                 .Include(x => x.Customer_Category)
                 .Include(x=>x.LOC)
                 .Include(x => x.Transactions)
                 .Single(x => x.CustomerId == id)
            );
        }

        public CustomerDto GetByEmail(string Email)
        {
            return _mapper.Map<CustomerDto>(
                _context.Customers.Include(x=>x.LOC)
                .Include(x=>x.Customer_Category)
                .Single(x => x.UserEmail.ToLower() == Email.ToLower()));
        }

        public DataCollection<CustomerDto> GetOnlyCustomers(int page, int take)
        {
            return _mapper.Map<DataCollection<CustomerDto>>(
                 _context.Customers
                 .Where(x=>x.Customer_CategoryId == 2)
                              .Include(x => x.Orders)
                              .Include(x => x.Cards)
                              .Include(x=>x.LOC)
                              .Include(x => x.Customer_Category)
                              .OrderByDescending(x => x.CustomerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }
    }
}
