using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class QuoteDetailsConfig
    {
        public QuoteDetailsConfig(EntityTypeBuilder<QuoteDetail> entityBuilder)
        {
            entityBuilder.HasKey(x => x.QuoteDetailsId);
        }
    }
}
