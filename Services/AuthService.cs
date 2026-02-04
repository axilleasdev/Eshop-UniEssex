using EShop.Data;
using EShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    // Authentication Service - Single Responsibility
    // Διαχειρίζεται μόνο την αυθεντικοποίηση
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        // Επαλήθευση admin credentials
        public async Task<bool> ValidateAdminAsync(string username, string password)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
            
            return admin != null;
        }
    }
}
