using AutoMapper;
using System.Linq;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoodYeah.Service.Impl
{
    public class ProductServiceImpl : ProductService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;
        public ProductServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }

        public ProductDto Create(ProductCreateDto model)
        {
            Product_Category productCategory = _context.Product_Categories
            .Single(x => x.Product_CategoryId == model.Product_CategoryId);

            var entry = new Product
            {
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                Product_CategoryId = model.Product_CategoryId,
                Product_Category = productCategory,
                SellDay = model.SellDay,
                Stock = model.Stock,
                ImageUrl = model.ImageUrl,
                Ingredients = model.Ingredients,
                ProductId = id++
            };

            _context.Products.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<ProductDto>(entry);
        }

        public DataCollection<ProductDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ProductDto>>(
                  _context.Products.OrderByDescending(x => x.ProductId)
                               .Include(x => x.Product_Category)
                               .AsQueryable()
                               .Paged(page, take)
             );
        }

        public DataCollection<ProductSimpleDto> GetAllSimple(int page, int take)
        {
            return _mapper.Map<DataCollection<ProductSimpleDto>>(
                  _context.Products.OrderByDescending(x => x.ProductId)
                               .AsQueryable()
                               .Paged(page, take)
             );
        }

        public ProductDto GetById(int id)
        {
            return _mapper.Map<ProductDto>(
                _context.Products.Include(x => x.Product_Category).Single(x => x.ProductId == id)
           );
        }

        public void Remove(int id)
        {
            _context.Remove(new Product
            {
                ProductId = id
            });

            _context.SaveChanges();
        }

        public void Update(int id, ProductUpdateDto model)
        {
            var entry = _context.Products.Single(x => x.ProductId == id);

            entry.ProductName = model.ProductName;
            entry.ProductPrice = model.ProductPrice;
            entry.Product_CategoryId = model.Product_CategoryId;
            entry.SellDay = model.SellDay;
            entry.Stock = model.Stock;
            entry.ImageUrl = model.ImageUrl;
            entry.Ingredients = model.Ingredients;

            _context.SaveChanges();
        }

        public void AddStock(int id, ProductUpdateStockDto model)
        {
            var entry = _context.Products.Single(x => x.ProductId == id);
            entry.Stock += model.AddStock;

            _context.SaveChanges();
        }
        public DataCollection<ProductDto> GetByWeek(int page, int take)
        {
            return _mapper.Map<DataCollection<ProductDto>>(
                     _context.Products.OrderByDescending(x => x.ProductId)
                                .OrderBy(x => x.SellDay)
                                  .Include(x => x.Product_Category)
                                  .AsQueryable()
                                  .Paged(page, take)
                );
        }
        public DataCollection<ProductDto> GetByDay(Enums.DaySold day, int page, int take)
        {
            return _mapper.Map<DataCollection<ProductDto>>(
                     _context.Products.Where(x => x.SellDay == day)
                     .OrderBy(x => x.SellDay)
                     .Include(x => x.Product_Category)
                     .AsQueryable()
                     .Paged(page, take)
                );
        }
    }
}
