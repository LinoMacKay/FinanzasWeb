using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class Product_CategoryConfig
    {
        public Product_CategoryConfig(EntityTypeBuilder<Product_Category> entityBuilder)
        {
            entityBuilder.Property(x => x.Product_CategoryId).IsRequired();
            entityBuilder.Property(x => x.Product_CategoryName).IsRequired();
            entityBuilder.Property(x => x.Product_CategoryDescription).IsRequired();
        }
    }
}
