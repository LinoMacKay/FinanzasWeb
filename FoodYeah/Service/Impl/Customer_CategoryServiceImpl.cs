using System.Linq;
using AutoMapper;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoodYeah.Service
{
    public class Customer_CategoryServiceImpl : Customer_CategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;
        public Customer_CategoryServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }
        public Customer_CategoryDto Create(Customer_CategoryCreateDto model)
        {
            var entry = new Customer_Category
            {
                Customer_CategoryName = model.Customer_CategoryName,
                Customer_CategoryDescription = model.Customer_CategoryDescription,
                Customer_CategoryId = id++
            };
            
            _context.Customer_Categories.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<Customer_CategoryDto>(entry);
        }

        public DataCollection<Customer_CategoryDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<Customer_CategoryDto>>(
                _context.Customer_Categories
                        .Include(x => x.Customers)
                        .OrderByDescending(x => x.Customer_CategoryId)
                        .AsQueryable()
                        .Paged(page, take)
            );
        }

        public DataCollection<Customer_CategorySimpleDto> GetAllSimple(int page, int take)
        {
            return _mapper.Map<DataCollection<Customer_CategorySimpleDto>>(
                _context.Customer_Categories
                        .OrderByDescending(x => x.Customer_CategoryId)
                        .AsQueryable()
                        .Paged(page, take)
            );
        }

        public Customer_CategoryDto GetById(int id)
        {
            return _mapper.Map<Customer_CategoryDto>(
                _context.Customer_Categories.Single(x => x.Customer_CategoryId == id)
           );
        }

        public void Remove(int id)
        {
            _context.Remove(new Customer_Category
            {
                Customer_CategoryId = id
            });

            _context.SaveChanges();
        }

        public void Update(int id, Customer_CategoryUpdateDto model)
        {
            var entry = _context.Customer_Categories.Single(x => x.Customer_CategoryId == id);
            
            entry.Customer_CategoryName = model.Customer_CategoryName;
            entry.Customer_CategoryDescription = model.Customer_CategoryDescription;

            _context.SaveChanges();
        }
    }

}