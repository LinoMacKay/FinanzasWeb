using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface ProductService
    {
        DataCollection<ProductDto> GetAll(int page, int take);
        DataCollection<ProductSimpleDto> GetAllSimple(int page, int take);
        ProductDto GetById(int id);
        DataCollection<ProductDto> GetByWeek(int page, int take);
        DataCollection<ProductDto> GetByDay(Enums.DaySold day, int page, int take);
        ProductDto Create(ProductCreateDto model);
        void AddStock(int id, ProductUpdateStockDto model);
        void Update(int id, ProductUpdateDto model);
        void Remove(int id);
    }
}
    