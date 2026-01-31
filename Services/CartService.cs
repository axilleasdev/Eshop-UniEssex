using EShop.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace EShop.Services
{
    public class CartService : ICartService
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IProductService _productService;
        private const string CartKey = "shopping_cart";

        public CartService(ProtectedSessionStorage sessionStorage, IProductService productService)
        {
            _sessionStorage = sessionStorage;
            _productService = productService;
        }

        public async Task AddToCartAsync(int productId, int quantity = 1)
        {
            var cart = await GetCartItemsAsync();
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null || !product.IsAvailable) return;

            var existingItem = cart.FirstOrDefault(c => c.ProductId == productId);
            
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    ImageFileName = product.ImageFileName
                });
            }

            await _sessionStorage.SetAsync(CartKey, cart);
        }

        public async Task RemoveFromCartAsync(int productId)
        {
            var cart = await GetCartItemsAsync();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            
            if (item != null)
            {
                cart.Remove(item);
                await _sessionStorage.SetAsync(CartKey, cart);
            }
        }

        public async Task UpdateQuantityAsync(int productId, int quantity)
        {
            var cart = await GetCartItemsAsync();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            
            if (item != null)
            {
                if (quantity <= 0)
                {
                    await RemoveFromCartAsync(productId);
                }
                else
                {
                    item.Quantity = quantity;
                    await _sessionStorage.SetAsync(CartKey, cart);
                }
            }
        }

        public async Task ClearCartAsync()
        {
            await _sessionStorage.DeleteAsync(CartKey);
        }

        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            try
            {
                var result = await _sessionStorage.GetAsync<List<CartItem>>(CartKey);
                return result.Success ? result.Value ?? new List<CartItem>() : new List<CartItem>();
            }
            catch
            {
                return new List<CartItem>();
            }
        }

        public async Task<int> GetCartCountAsync()
        {
            var cart = await GetCartItemsAsync();
            return cart.Sum(c => c.Quantity);
        }

        public async Task<decimal> GetCartTotalAsync()
        {
            var cart = await GetCartItemsAsync();
            return cart.Sum(c => c.TotalPrice);
        }
    }
}
