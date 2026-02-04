using Microsoft.EntityFrameworkCore;
using EShop.Models;

namespace EShop.Data
{
    // Database Context - Entity Framework Core
    // Διαχειρίζεται τη σύνδεση με τη βάση και τα DbSets
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets - αντιπροσωπεύουν πίνακες στη βάση
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration για υπάρχοντα πίνακα Menu
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menus");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.MenuTitle).HasColumnName("menutitle");
                entity.Property(e => e.Link).HasColumnName("link");
                entity.Property(e => e.Type).HasColumnName("type");
            });

            // Exclude από migrations (ο πίνακας υπάρχει ήδη)
            modelBuilder.Entity<Menu>().ToTable("menus", t => t.ExcludeFromMigrations());
        }
    }
}
