using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface Product_CategoryService
    {
        DataCollection<Product_CategoryDto> GetAll(int page, int take);
        DataCollection<Product_CategorySimpleDto> GetAllSimple(int page, int take);
        Product_CategoryDto GetById(int id);
        Product_CategoryDto Create(Product_CategoryCreateDto model);
        void Update(int id, Product_CategoryUpdateDto model);
        void Remove(int id);
    }
}