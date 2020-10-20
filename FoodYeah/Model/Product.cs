using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodYeah.Commons;


namespace FoodYeah.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public int Product_CategoryId { get; set; }
        public Product_Category Product_Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Enums.DaySold SellDay { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
