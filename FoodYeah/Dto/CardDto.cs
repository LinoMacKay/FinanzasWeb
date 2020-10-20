using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Dto
{
    public class CardCreateDto
    {
        [Required]
        public long CardNumber { get; set; }
        public int CustomerId { get; set; }
        public bool CardType { get; set; }
        public int CardCvi  { get; set; }
        public string CardExpireDate { get; set; }
    }

    public class CardUpdateDto
    {
        public string CardOwnerName { get; set; }
    }

    public class CardDto
    {
        public int CardId { get; set; }
        public long CardNumber { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public bool CardType { get; set; }
        public int CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public string CardExpireDate { get; set; }
        public decimal Money { get; set; }
    }

     public class CardSimpleDto
    {
        public int CardId { get; set; }
        public long CardNumber { get; set; }
        public int CustomerId { get; set; }
        public bool CardType { get; set; }
        public int CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public string CardExpireDate { get; set; }
        public decimal Money { get; set; }
    }
}
