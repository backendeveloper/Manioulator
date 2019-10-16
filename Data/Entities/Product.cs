using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required]
        public string ProductCode { get; set; }
        
        [Required]
        public float Price { get; set; }
        
        [Required]
        public int Stock { get; set; }
        
        public float ChangedPrice { get; set; }

    }
}