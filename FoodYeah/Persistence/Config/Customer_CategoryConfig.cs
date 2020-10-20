using FoodYeah.Commons;
using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class Customer_CategoryConfig
    {
        public Customer_CategoryConfig(EntityTypeBuilder<Customer_Category> entityBuilder)
        {
            entityBuilder.Property(x => x.Customer_CategoryId).IsRequired();
            entityBuilder.Property(x => x.Customer_CategoryName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Customer_CategoryDescription).IsRequired();
            entityBuilder.HasData(
                new Customer_Category
                {
                    Customer_CategoryId = 1,
                    Customer_CategoryName = "Owner",
                    Customer_CategoryDescription = "Owner"

                },
                new Customer_Category
                {
                    Customer_CategoryId = 2,
                    Customer_CategoryName = "Client",
                    Customer_CategoryDescription = "Client"
                }
                ); ; 
                


        }
    }
}
