using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public decimal Price { get; set; }
        
        public int Stock { get; set; }
        
        [StringLength(255)]
        public string? ImageFileName { get; set; }
    }
}
