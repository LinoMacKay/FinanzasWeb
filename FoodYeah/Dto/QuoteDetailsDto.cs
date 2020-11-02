using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class QuoteDetailsDto
    {
        public int NumberQuotes { get; set; }
        public List<decimal> Quotes { get; set; }
        public int Frecuency { get; set; }
        public int PaymentType { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LastTotal { get; set; }
    }

    public class CreateQuoteDetailsDto
    {
        public int NumberQuotes { get; set; }
        public int Frecuency { get; set; }
        public int PaymentType { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LastTotal { get; set; }
    }

    public class UpdateQuoteDetailsDto
    {
       public int QuoteDetailsId { get; set; }
        public int NumberQuotes { get; set; }
        public List<decimal> Quotes { get; set; }
        public int Frecuency { get; set; }
        public int PaymentType { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LastTotal { get; set; }

    }
    public class DeleteQuoteDetailsDto
    {
        public int QuoteDetailsId { get; set; }
    }

}
