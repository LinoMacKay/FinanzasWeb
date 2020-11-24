using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Controllers
{
    [Route("quote")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly QuoteService _quoteService;

        public QuoteController(QuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("quotedetails/{QuoteDetailsid}")]
        public ActionResult<List<QuoteDto>> GetAll(int QuoteDetailsid) => _quoteService.GetByQuoteDetailId(QuoteDetailsid);



        [HttpGet("updateInterest/{QuoteDetailsid}")]
        public ActionResult<List<QuoteDto>> UpdateInterest(int QuoteDetailsid) => _quoteService.UpdateInterest(QuoteDetailsid);


        [HttpPut("pay/{quoteId}/{amount}")]
        public ActionResult Pay(int quoteId, decimal amount) // Probando si con el update se podria pagar
        {
            _quoteService.PayQuote(quoteId, amount);
            return NoContent();
        }

    }
}
