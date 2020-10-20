using System.Collections.Generic;
using FoodYeah.Commons;

namespace FoodYeah.Dto
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Product_CategoryId { get; set; }
        public Enums.DaySold SellDay { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; }
    }

    public class ProductUpdateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Product_CategoryId { get; set; }
        public Enums.DaySold SellDay { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; }
    }

    public class ProductUpdateStockDto
    {
        public int AddStock { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public Product_CategoryDto Product_Category { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Enums.DaySold SellDay { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; }
    }

    public class ProductSimpleDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Enums.DaySold SellDay { get; set; }
        public int Stock { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
