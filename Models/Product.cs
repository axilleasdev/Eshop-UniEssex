using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    // Κλάση Product - Inheritance από BaseEntity, Encapsulation με properties
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public decimal Price { get; set; }
        
        public int Stock { get; set; }
        
        [StringLength(255)]
        public string? ImageFileName { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        // Computed property - ελέγχει διαθεσιμότητα
        public bool IsAvailable => Stock > 0;

        // Override - Polymorphism
        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
