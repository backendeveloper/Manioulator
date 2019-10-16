using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}