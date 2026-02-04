namespace EShop.Models
{
    // Model για Cart Item - Encapsulation
    // Χρησιμοποιείται για session storage (δεν αποθηκεύεται στη βάση)
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageFileName { get; set; }

        // Computed property - υπολογίζει το συνολικό κόστος
        public decimal TotalPrice => Price * Quantity;
    }
}
