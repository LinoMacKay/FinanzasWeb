using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Controllers
{
    [Route("transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;
        public TransactionController(TransactionService transactionService) => _transactionService = transactionService;
        [HttpPost]
        public ActionResult Create(TransactionCreateDto transaction)
        {
            var result = _transactionService.Create(transaction);
            return CreatedAtAction(
                "GetById",
                new { id = result.TransactionId },
                result
            );
        }
    }
}
