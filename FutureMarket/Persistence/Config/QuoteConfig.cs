using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class QuoteConfig
    {
        public QuoteConfig(EntityTypeBuilder<Quote> entityBuilder)
        {

            entityBuilder.HasOne(x => x.QuoteDetail).WithMany(x => x.Quotes).HasForeignKey(x=>x.QuoteDetailsId);
        }
    }
}
