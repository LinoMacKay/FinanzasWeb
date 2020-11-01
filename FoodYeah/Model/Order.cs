using System.Collections.Generic;

namespace FoodYeah.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Date { get; set; }
        public string InitTime { get; set; }
        public string EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        // Todo lo que tiene que ver con el pago
        public int NumberQuotes {get; set; }
        public List<decimal> Quotes {get; set; }
        public int Frecuency {get; set; }
        public int PaymentType {get; set; }
        public decimal InterestRate {get; set; }
        public decimal LastTotal {get; set; }
    }
}
