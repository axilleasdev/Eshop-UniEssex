using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class Admin : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;
    }
}
