using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface CustomerService
    {
        DataCollection<CustomerDto> GetAll(int page, int take);
        DataCollection<CustomerSimpleDto> GetAllSimple(int page, int take);
        CustomerDto GetById(int id);
        DataCollection<CustomerDto> GetOnlyCustomers(int page, int take);
        CustomerDto Create(CustomerCreateDto model);
        CustomerDto GetByEmail(string Email);
        void Update(int id, CustomerUpdateDto model);
        void Remove(int id);
    }
}
