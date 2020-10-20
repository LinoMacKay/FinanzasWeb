using FoodYeah.Model.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int Customer_CategoryId { get; set; }
        public Customer_Category Customer_Category { get; set; }
        public List<Card> Cards { get; set; } 
        public List<Order> Orders {get; set;}
        public string Email { get; set; }
        public LOC LOC { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public byte CustomerAge { get; set; }
    }
}
