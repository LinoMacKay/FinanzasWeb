using FoodYeah.Model;
using FoodYeah.Model.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class ApplicationUserConfig
    {

        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.Property(x => x.FirstName).IsRequired();
            entityBuilder.Property(x => x.Age).IsRequired();
            entityBuilder.HasMany(x => x.UserRoles).WithOne(x => x.User)
                .HasForeignKey(x => x.UserId).IsRequired();
            entityBuilder.HasOne(x => x.Customer).WithOne(x => x.User).HasForeignKey<Customer>(x => x.Email);
        }
    }
}
