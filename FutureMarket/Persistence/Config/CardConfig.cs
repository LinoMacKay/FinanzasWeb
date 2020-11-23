using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class CardConfig
    {
        public CardConfig(EntityTypeBuilder<Card> entityBuilder)
        {
            entityBuilder.Property(x => x.CardId).IsRequired();
            entityBuilder.Property(x => x.CardNumber).IsRequired();
            entityBuilder.Property(x => x.CardType).IsRequired();
            entityBuilder.Property(x => x.CardCvi).IsRequired();
            entityBuilder.Property(x => x.CardOwnerName).IsRequired();
            entityBuilder.Property(x => x.CardExpireDate).IsRequired();
            entityBuilder
            .HasOne(x => x.Customer)
            .WithMany(x => x.Cards)
            .HasForeignKey(x => x.CustomerId); 
        }
    }
}
