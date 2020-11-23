using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Model
{ 
    public class Product_Category
    {
        public int Product_CategoryId { get; set; }

        
        public List<Product> Products { get; set; }
        [Required]
        public string Product_CategoryName { get; set; }
        [Required]
        public string Product_CategoryDescription { get; set; }
    }
}
