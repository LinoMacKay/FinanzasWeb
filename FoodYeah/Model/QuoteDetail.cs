using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class QuoteDetail
    {
        public int QuoteDetailsId { get; set; }
        public LOC Loc { get; set; }
        public int LocId { get; set; }
        public int NumberQuotes { get; set; }
        public List<decimal> Quotes { get; set; }
        public int Frecuency { get; set; }
        public string Currency { get; set; }
        public decimal Debt { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LastTotal { get; set; }
        public DateTime FirstPaidDay { get; set; }
        public DateTime LastPaidDay { get; set; }
    }
}
