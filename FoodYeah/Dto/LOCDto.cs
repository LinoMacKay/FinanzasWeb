using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class LOCDto
    {
        public int LOCId { get; set; }
        public decimal TEA { get; set; }
        public decimal LineOfCredit { get; set; }
        public decimal TotalLineOfCredit { get; set; }
        public decimal AvalibleLineOfCredit { get; set; }

        
    }
    public class CreateLOCDto
    {
        public int CustomerId { get; set; }
        public decimal TEA { get; set; }
        public decimal TotalLineOfCredit { get; set; }
        
    }
    public class UpdateLOCDto
    {
        public int LOCId { get; set; }
        public decimal TEA { get; set; }
        public decimal TotalLineOfCredit { get; set; }
       
    }
    public class DeleteLOCDto
    {
        public int LOCId { get; set; }
    }
}
