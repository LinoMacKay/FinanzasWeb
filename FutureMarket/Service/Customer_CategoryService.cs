using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface Customer_CategoryService
    {
        DataCollection<Customer_CategoryDto> GetAll(int page, int take);
        DataCollection<Customer_CategorySimpleDto> GetAllSimple(int page, int take);
        Customer_CategoryDto GetById(int id);
        Customer_CategoryDto Create(Customer_CategoryCreateDto model);
        void Update(int id, Customer_CategoryUpdateDto model);
        void Remove(int id);
    }
}