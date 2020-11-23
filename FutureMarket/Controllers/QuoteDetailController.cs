using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Controllers
{
    [Route("quotedetail")]
    [ApiController]
    public class QuoteDetailController : ControllerBase
    {
        private readonly QuoteDetailService _quoteDetailService;
        public QuoteDetailController(QuoteDetailService quoteDetailService)
        {
            _quoteDetailService = quoteDetailService;
        }
        [HttpGet]
        public ActionResult<DataCollection<QuoteDetailsDto>> GetAll(int page = 1, int take = 20)
        {
            return _quoteDetailService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public ActionResult<QuoteDetailsDto> GetById(int id) => _quoteDetailService.GetById(id);

        [HttpPost]
        public ActionResult Create(CreateQuoteDetailsDto QuoteDetail, int orderId)
        {
            var result = _quoteDetailService.Create(QuoteDetail, orderId);
            return CreatedAtAction(
                "GetById",
                new { id = result.QuoteDetailsId },
                result
            );
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id) // Probando si con el update se podria pagar
        {
            //_quoteDetailService.Update(id);
            //_quoteDetailService.PayQuote(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _quoteDetailService.Remove(id);
            return NoContent();
        }

        [HttpPut("pay/{id}/{amount}")]
        public ActionResult Pay(int id,decimal amount) // Probando si con el update se podria pagar
        {
            _quoteDetailService.PayQuote(amount,id);
            return NoContent();
        }
    }
}
