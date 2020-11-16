using FoodYeah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
    public class TransactionCreateDto
    {
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

    public class TransactionSimpleDto
    {
        public int TransactionId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
