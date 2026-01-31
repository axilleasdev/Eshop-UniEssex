using EShop.Models;

namespace EShop.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(int productId, int quantity = 1);
        Task RemoveFromCartAsync(int productId);
        Task UpdateQuantityAsync(int productId, int quantity);
        Task ClearCartAsync();
        Task<List<CartItem>> GetCartItemsAsync();
        Task<int> GetCartCountAsync();
        Task<decimal> GetCartTotalAsync();
    }
}
