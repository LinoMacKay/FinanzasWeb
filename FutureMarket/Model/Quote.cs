using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public int QuoteDetailsId { get; set; }
        public QuoteDetail QuoteDetail { get; set; }
        public decimal Value { get; set; }
        public decimal Interest { get; set; }
        public DateTime FirstPaidDay { get; set; }
        public DateTime LastPaidDay { get; set; }
    }
}
