using FoodYeah.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class QuoteDetailsDto
    {
        public int QuoteDetailsId { get; set; }
        public LOC Loc { get; set; }
        public int LocId { get; set; }
        public int NumberQuotes { get; set; }
        public List<Quote> Quotes { get; set; }
        public int Frecuency { get; set; }
        public string Currency { get; set; }
        public int PaymentType { get; set; }
        public decimal Debt { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LastTotal { get; set; }
    }

    public class CreateQuoteDetailsDto
    {
        public int LocId { get; set; }
        public int NumberQuotes { get; set; }
        public int Frecuency { get; set; }
        public string Currency { get; set; }
    }

    public class UpdateQuoteDetailsDto
    {
        public int QuoteDetailsId { get; set; }
        public int NumberQuotes { get; set; }
        public List<Quote> Quotes { get; set; }
        public int Frecuency { get; set; }
        public string Currency { get; set; }
        public int PaymentType { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LastTotal { get; set; }

    }
    public class DeleteQuoteDetailsDto
    {
        public int QuoteDetailsId { get; set; }
    }

    public class SimpleQuoteDetailsDtos
    {
        public int QuoteDetailsId { get; set; }
        public List<QuoteDto> Quotes { get; set; }
        public int NumberQuotes { get; set; }
        public int Frecuency { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Debt { get; set; }
        public string Currency { get; set; }
        public decimal LastTotal { get; set; }
        public DateTime FirstPaidDay { get; set; }
        public DateTime LastPaidDay { get; set; }


    }

    public class CurrencyDto
    {
        public string Base { get; set; }
        public string Date { get; set; }
        public Rates Rates { get; set; }
    }

    public class Rates
    {
        public string PEN { get; set; }
    }
}
