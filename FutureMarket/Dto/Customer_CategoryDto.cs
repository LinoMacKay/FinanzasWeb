using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Dto
{
    public class Customer_CategoryCreateDto
    {
        public string Customer_CategoryName { get; set; }
        public string Customer_CategoryDescription { get; set; }
    }

    public class Customer_CategoryUpdateDto
    {
        public string Customer_CategoryName { get; set; }
        public string Customer_CategoryDescription { get; set; }
    }

    public class Customer_CategoryDto
    {
        public int Customer_CategoryId { get; set; }
        [Required]
        public List<CustomerDto> Customers { get; set; }
        public string Customer_CategoryName { get; set; }
        public string Customer_CategoryDescription { get; set; }
    }

    public class Customer_CategorySimpleDto
    {
        public int Customer_CategoryId { get; set; }
        [Required]
        public string Customer_CategoryName { get; set; }
        public string Customer_CategoryDescription { get; set; }
    }
}