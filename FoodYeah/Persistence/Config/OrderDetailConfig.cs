using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class OrderDetailConfig
    {
        public OrderDetailConfig(EntityTypeBuilder<OrderDetail> entityBuilder)
        {
            entityBuilder.Property(x => x.OrderDetailId).IsRequired();
            entityBuilder.Property(x => x.Quantity).IsRequired();
            entityBuilder.Property(x => x.UnitPrice).IsRequired();
            entityBuilder.Property(x => x.TotalPrice).IsRequired();
            entityBuilder
            .HasOne(x => x.Product)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.ProductId);
            entityBuilder
            .HasOne(x => x.Order)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.OrderId);
        }
    }
}
