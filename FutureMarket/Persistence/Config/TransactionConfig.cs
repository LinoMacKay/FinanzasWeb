using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class TransactionConfig
    {
        public TransactionConfig(EntityTypeBuilder<Transaction> entityBuilder)
        {
            entityBuilder.HasKey(x => x.TransactionId);
            entityBuilder.Property(x => x.Status).IsRequired();
            entityBuilder.Property(x => x.Description).IsRequired();
            entityBuilder.HasOne(x => x.Customer).WithMany(x => x.Transactions).HasForeignKey(x => x.CustomerId);
        }
    }
}
