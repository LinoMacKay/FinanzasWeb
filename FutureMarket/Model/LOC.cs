using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static FoodYeah.Commons.Enums;

namespace FoodYeah.Model
{
    public class LOC
    {
        [ForeignKey("Customer")]
        public int LOCId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public decimal Rate { get; set; }
        public TypeRate TypeRate { get; set; }
        public List<QuoteDetail> QuoteDetails { get; set; }
        public decimal AvalibleLineOfCredit { get; set; }
        public decimal TotalLineOfCredit { get; set; }

    }
}
