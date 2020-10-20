using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using System.Globalization;

namespace FoodYeah.Service.Impl
{
    public class OrderServiceImpl : OrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;

        public OrderServiceImpl(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }

        public OrderDto Create(OrderCreateDto model)
        {
            var entry = _mapper.Map<Order>(model);

            PrepareDetail(entry.OrderDetails);

            PrepareHeader(entry);

            _context.Orders.Add(entry);
            _context.SaveChanges();


            return _mapper.Map<OrderDto>(GetById(entry.OrderId)
            );
        }

        public DataCollection<OrderDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                _context.Orders.OrderByDescending(x => x.OrderId)
                                   .Include(x => x.Customer)
                                   .Include(x => x.OrderDetails)
                                    .ThenInclude(x => x.Order)
                                   .Include(x => x.OrderDetails)
                                    .ThenInclude(x => x.Product)
                                   .AsQueryable()
                                   .Paged(page, take)
           );
        }

        public DataCollection<OrderSimpleDto> GetAllSimple(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderSimpleDto>>(
                _context.Orders.OrderByDescending(x => x.OrderId)
                    .AsQueryable()
                    .Paged(page, take)
           );
        }

        public OrderDto GetById(int id)
        {
            return _mapper.Map<OrderDto>(
                  _context.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Order)
                    .Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .Single(x => x.OrderId == id)
             );
        }

        public OrderSimpleDto GetByIdSimple(int id)
        {
            return _mapper.Map<OrderSimpleDto>(
                  _context.Orders
                    .Single(x => x.OrderId == id)
             );
        }
        private void PrepareDetail(IEnumerable<OrderDetail> orderDetails)
        {
            foreach (var item in orderDetails)
            {
                Product product = _context.Products.Single(x => x.ProductId == item.ProductId);
                item.UnitPrice = product.ProductPrice;
                item.TotalPrice = item.UnitPrice * item.Quantity;
            }
        }

        private void PrepareHeader(Order order)
        {
            order.OrderId = id++;
            order.Date = DateTime.Now.ToString("yyyy-MM-dd");
            order.TotalPrice = order.OrderDetails.Sum(x => x.TotalPrice);
            order.InitTime = DateTime.Now.ToString("hh:mm:ss tt");
            order.EndTime = "00:00:00";
            order.Status = "NOTDELIVERED";
        }

        ////////////////////////////////////////////////////////////////////////////
        public void SetEndTime(int id)
        {
            var order = _context.Orders.Single(x => x.OrderId == id);
            order.EndTime = DateTime.Now.ToString("hh:mm:ss tt");

            _context.SaveChanges();
        }

        public void DecreaseStock(int id)
        {
            var order = _context.Orders
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .Single(x => x.OrderId == id);
            foreach (var item in order.OrderDetails)
            {
                item.Product.Stock -= item.Quantity;
            }
            _context.SaveChanges();
        }

        public string GetAverageTime()
        {
            var averageTime = TimeSpan.Parse("00:00:00");
            int cantidad = 0;

            foreach (var order in _context.Orders)
            {
                if (order.EndTime == "00:00:00")
                    continue;
                cantidad++;
                DateTime _initTime = DateTime.Parse(order.InitTime);
                DateTime _endTime = DateTime.Parse(order.EndTime);
                averageTime += _endTime - _initTime;
            }

            if (cantidad == 0)
                return ("00:05:00");

            averageTime = averageTime.Divide(cantidad);
            return averageTime.ToString();
        }

        public OrderSimpleDto UpdateStatus(int id, string status)
        {
            var estado = status.ToUpper();
            var orden = _context.Orders.Single(x => x.OrderId == id);
            orden.Status = estado;

            _context.SaveChanges();
            return _mapper.Map<OrderSimpleDto>(GetByIdSimple(orden.OrderId));
        }

        public string GetDeliveredOrder(int id)
        {
            string message;
            var item = _context.Orders.Single(x => x.OrderId == id);
            if (item.Status == "DELIVERED")
                message = "La orden se ha entregado correctamente";
            else
                message = "Orden en preparacion";
            return message;
        }

        public bool DecreaseCostumerMoney(int cardId, int orderId)
        {
            var order = _context.Orders.Single(x => x.OrderId == orderId);
            var card = _context.Cards.Single(x => x.CardId == cardId);

            if ((card.Money - order.TotalPrice) >= 0)
            {
                card.Money -= order.TotalPrice;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}