using System.Linq;
using AutoMapper;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoodYeah.Service
{
    public class Product_CategoryServiceImpl : Product_CategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;
        public Product_CategoryServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }
        public Product_CategoryDto Create(Product_CategoryCreateDto model)
        {
            var entry = new Product_Category
            {
                Product_CategoryName = model.Product_CategoryName,
                Product_CategoryDescription = model.Product_CategoryDescription,
                Product_CategoryId = id++
            };
            
            _context.Product_Categories.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<Product_CategoryDto>(entry);
        }

        public DataCollection<Product_CategoryDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<Product_CategoryDto>>(
                _context.Product_Categories
                        .Include(x => x.Products)
                        .OrderByDescending(x => x.Product_CategoryId)
                        .AsQueryable()
                        .Paged(page, take)
            );
        }

         public DataCollection<Product_CategorySimpleDto> GetAllSimple(int page, int take)
        {
            return _mapper.Map<DataCollection<Product_CategorySimpleDto>>(
                _context.Product_Categories
                        .OrderByDescending(x => x.Product_CategoryId)
                        .AsQueryable()
                        .Paged(page, take)
            );
        }

        public Product_CategoryDto GetById(int id)
        {
            return _mapper.Map<Product_CategoryDto>(
                _context.Product_Categories.Single(x => x.Product_CategoryId == id)
           );
        }

        public void Remove(int id)
        {
            _context.Remove(new Product_Category
            {
                Product_CategoryId = id
            });

            _context.SaveChanges();
        }

        public void Update(int id, Product_CategoryUpdateDto model)
        {
            var entry = _context.Product_Categories.Single(x => x.Product_CategoryId == id);
            
            entry.Product_CategoryName = model.Product_CategoryName;
            entry.Product_CategoryDescription = model.Product_CategoryDescription;

            _context.SaveChanges();
        }
    }

}