using FoodYeah.Commons;
using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FoodYeah.Persistence.Config
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.Property(x => x.SellDay).HasConversion(x => x.ToString(), // to converter
                x => (Enums.DaySold)Enum.Parse(typeof(Enums.DaySold), x));
            entityBuilder.Property(x => x.ProductId).IsRequired();
            entityBuilder.Property(x => x.ProductName).IsRequired();
            entityBuilder.Property(x => x.ProductPrice).IsRequired();
            entityBuilder.Property(x => x.Stock).IsRequired();
            entityBuilder.Property(x => x.ImageUrl).IsRequired();
            entityBuilder.Property(x => x.Ingredients).IsRequired();
            entityBuilder
            .HasOne(x => x.Product_Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.Product_CategoryId);
        }
    }
}
