namespace EShop.Models
{
    // Abstract βασική κλάση - Abstraction & Inheritance
    // Όλες οι entities κληρονομούν κοινά πεδία (Id, CreatedAt, UpdatedAt)
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Virtual method για Polymorphism - επιτρέπει override στις παράγωγες κλάσεις
        public virtual void OnUpdate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
