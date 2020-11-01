using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class OrderConfig
    {
        public OrderConfig(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.Property(x => x.OrderId).IsRequired();
            entityBuilder.Property(x => x.Date).IsRequired();
            entityBuilder.Property(x => x.Status).IsRequired();
            entityBuilder.Property(x => x.InitTime).IsRequired();
            entityBuilder.Property(x => x.EndTime).IsRequired();
            entityBuilder.Property(x => x.TotalPrice).IsRequired();
            //
            entityBuilder.Property(x => x.NumberQuotes).IsRequired();
            entityBuilder.Property(x => x.Quotes).IsRequired();
            entityBuilder.Property(x => x.Frecuency).IsRequired();
            entityBuilder.Property(x => x.PaymentType).IsRequired();
            entityBuilder.Property(x => x.InterestRate).IsRequired();
            entityBuilder.Property(x => x.LastTotal).IsRequired();
            //
            entityBuilder
            .HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId);
        }
    }
}
