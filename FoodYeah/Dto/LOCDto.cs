using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class LOCDto
    {
        public float TCEA { get; set; }
        public int LineOfCredit { get; set; }
        public int AvalibleLineOfCredit { get; set; }

        
    }
    public class CreateLOCDto
    {
        public int CustomerId { get; set; }
        public float TCEA { get; set; }
        public int TotalLineOfCredit { get; set; }
        
    }
    public class UpdateLOCDto
    {
        public float TCEA { get; set; }
        public int TotalLineOfCredit { get; set; }
       
    }
    public class DeleteLOCDto
    {
        public int LOCId { get; set; }
    }
}
