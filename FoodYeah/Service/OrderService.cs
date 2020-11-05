using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Service
{
    public interface OrderService
    {
        DataCollection<OrderDto> GetAll(int page, int take);
        DataCollection<OrderSimpleDto> GetAllSimple(int page, int take);
        OrderDto GetById(int id);
        OrderSimpleDto GetByIdSimple(int id);
        OrderSimpleDto UpdateStatus(int id, string status);
        OrderDto Create(OrderCreateDto model);
        string GetDeliveredOrder(int id);
        void SetEndTime(int id);
        string GetAverageTime();
        void DecreaseStock(int id);
        bool DecreaseCostumerMoney(int cardId, int orderId);
        //
        //void Pay(int CustomerId);
        //void SetPaymentConditions(int id, int numberQuotes = 1, int frecuency = 1, int paymentType = 1, decimal interestRate = 0);
    }
}
