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
                // AQUI ES DONDE SE TENDRÍA QUE CAMBIAR
                // 
                card.Money -= order.TotalPrice;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //
        public decimal TIS(decimal capital, int frecuency, decimal interestRate){
            // Tasa de interés simple : 1
            decimal s = capital * (1 + (interestRate * frecuency));
            return s;
        }
        //public decimal TIN(decimal capital, int frecuency, decimal interestRate, int numberQuotes, int rateType){
        //    // Tasa de interés nominal : 2
        //    decimal sub = (1 + (interestRate/(rateType/frecuency)));
        //    decimal s = capital * (Math.Pow(sub, numberQuotes));
        //    return s;
        //}
        public void TEP(){
            // Tasa efectiva de período : 3
            // Not implemented
        }

        public void SetPaymentConditions(int id, int numberQuotes = 1, int frecuency = 1, int paymentType = 1, decimal interestRate = 0)
        {
            throw new NotImplementedException();
        }

        public void Pay(int CustomerId)
        {







        }
        /*
capital = Order.TotalPrice (que es el precio sin los intereses)
Order.Frecuency (frecuencia de las cuotas que pagaras, por defecto esta en 1)
1: Diario | 15: Quincenal | 30: Mensual (Despues lo hacemos enum si quieres)
Order.InterestRate (tasa de interés, expresada en un decimal de 0 a 1, por defecto en 0)
Un InterestRate de 0.5 indica 50%
Order.NumberQuotes (literalmente es eso)
Order.PaymentType (en verdad es el tipo de tasa - sin especificacion de capitalizacion)
1: Tasa de Interes Simple | 2: Tasa de Interes Nominal
NOTA ADICIONAL: Además, para el caso de la tasa nominal, como necesita capitalizaciones
puse una variable que no entrara en la order y solo servira para el calculo, que es el
rateType. Ejemplo:
TASA NOMINAL ANUAL CON CAPITALIZACIONES MENSUALES, A 4 CUOTAS
rateType = 360 -> representa el ANUAL
frecuency = 30 -> capitalizacion MENSUAL
NumberQuotes = 4
Es por eso que arriba encontraras la formula de Tasa Interes Nominal (TIN) con esas cosas
Posiblemente esto se vaya a modificar bastante pero igual te lo dejo por si lo lees

*/
        //public void SetPaymentConditions(int id, int numberQuotes = 1, int frecuency = 1,int paymentType = 1, int rateType = 1, decimal interestRate = 0){
        //    var order = _context.Orders.Single(x => x.OrderId == id);
        //    order.NumberQuotes = numberQuotes;
        //    order.Frecuency = frecuency;
        //    order.PaymentType = paymentType;
        //    order.InterestRate = interestRate;
        //    switch (order.PaymentType)
        //    {
        //        case 1: order.LastTotal = TIS(order.TotalPrice, order.Frecuency, order.InterestRate); break;
        //        case 2: order.LastTotal = TIN(order.TotalPrice, order.Frecuency, order.InterestRate, order.NumberQuotes, rateType); break;
        //    }
        //    decimal q = ((order.LastTotal - order.TotalPrice) / order.NumberQuotes);
        //    for(int i = 0; i < order.NumberQuotes; i++){
        //        order.Quotes.Add(q);
        //    }
        //}




    }
}