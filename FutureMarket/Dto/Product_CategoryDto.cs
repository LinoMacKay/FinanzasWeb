using System.Collections.Generic;

namespace FoodYeah.Dto
{
    public class Product_CategoryCreateDto
    {
        public string Product_CategoryName { get; set; }
        public string Product_CategoryDescription { get; set; }
    }

    public class Product_CategoryUpdateDto
    {
        public string Product_CategoryName { get; set; }
        public string Product_CategoryDescription { get; set; }
    }

    public class Product_CategoryDto
    {
        public int Product_CategoryId { get; set; }
        public List<ProductDto> Products { get; set; }
        public string Product_CategoryName { get; set; }
        public string Product_CategoryDescription { get; set; }
    }

    public class Product_CategorySimpleDto
    {
        public int Product_CategoryId { get; set; }
        public string Product_CategoryName { get; set; }
        public string Product_CategoryDescription { get; set; }
    }
}