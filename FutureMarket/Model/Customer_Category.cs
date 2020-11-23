using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Model
{
    public class Customer_Category
    {
        public int Customer_CategoryId { get; set; }
        public List<Customer> Customers { get; set; }
        [Required]
        public string Customer_CategoryName { get; set; }
        public string Customer_CategoryDescription { get; set; }
    }
}
