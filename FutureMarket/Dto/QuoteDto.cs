using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class QuoteDto
    {
        public int QuoteId { get; set; }
        public decimal Value { get; set; }
        public decimal Interest { get; set; }
        public DateTime FirstPaidDay { get; set; }
        public DateTime LastPaidDay { get; set; }
    }

    public class CreateQuoteDto
    {
        public decimal Value { get; set; }
        public decimal Interest { get; set; }
        public DateTime FirstPaidDay { get; set; }
        public DateTime LastPaidDay { get; set; }
    }
    public class DeleteQuoteDto
    {
        public int QuoteId { get; set; }
    }



}
