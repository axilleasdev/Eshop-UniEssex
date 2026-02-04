using EShop.Data;
using EShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    // Implementation του IProductService - Single Responsibility Principle
    // Διαχειρίζεται μόνο τη λογική των προϊόντων
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        // Constructor Injection - Dependency Injection pattern
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAvailableProductsAsync()
        {
            return await _context.Products
                .Where(p => p.Stock > 0)
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
                throw new InvalidOperationException("Product not found");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.ImageFileName = product.ImageFileName;
            existingProduct.Description = product.Description;
            existingProduct.OnUpdate();

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsProductAvailableAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product?.IsAvailable ?? false;
        }

        public async Task<bool> ReduceStockAsync(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null || product.Stock < quantity)
                return false;

            product.Stock -= quantity;
            product.OnUpdate();
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
