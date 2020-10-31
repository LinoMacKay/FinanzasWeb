using FoodYeah.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class LOCConfig
    {
        public LOCConfig(EntityTypeBuilder<LOC>entityBuilder)
        {
            entityBuilder.Property(x => x.LOCId).HasIdentityOptions();
        }
    }
}
