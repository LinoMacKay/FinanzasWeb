using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class QuoteDetailsConfig
    {
        public QuoteDetailsConfig(EntityTypeBuilder<QuoteDetail> entityBuilder)
        {
            entityBuilder.HasKey(x => x.QuoteDetailsId);
            entityBuilder.Property(x => x.NumberQuotes).IsRequired();
            entityBuilder.Property(x => x.Frecuency).IsRequired();
            entityBuilder.Property(x => x.PaymentType).IsRequired();
            entityBuilder.Property(x => x.Debt).IsRequired();
            entityBuilder.Property(x => x.InterestRate).IsRequired();
            entityBuilder.Property(x => x.LastTotal).IsRequired();
            entityBuilder.HasOne(x => x.Loc).WithMany(x => x.QuoteDetails).HasForeignKey(x => x.LocId);
        }
    }
}
