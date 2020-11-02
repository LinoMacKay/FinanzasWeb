using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class TransactionConfig
    {
        public TransactionConfig(EntityTypeBuilder<Transaction> entityBuilder)
        {
        }
    }
}
