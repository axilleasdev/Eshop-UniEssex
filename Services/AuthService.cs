using EShop.Data;
using EShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateAdminAsync(string username, string password)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Username == username);
            
            if (admin == null)
                return false;

            // Temporary: Check both BCrypt and plain text for compatibility
            try
            {
                // Try BCrypt first
                if (BCrypt.Net.BCrypt.Verify(password, admin.Password))
                    return true;
            }
            catch
            {
                // If BCrypt fails, try plain text (for backward compatibility)
                if (admin.Password == password)
                    return true;
            }

            return false;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
