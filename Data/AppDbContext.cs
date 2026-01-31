using Microsoft.EntityFrameworkCore;
using EShop.Models;

namespace EShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Menu to map to existing table (exclude from migrations)
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menus");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.MenuTitle).HasColumnName("menutitle");
                entity.Property(e => e.Link).HasColumnName("link");
                entity.Property(e => e.Type).HasColumnName("type");
            });

            // Exclude Menu from migrations since it already exists
            modelBuilder.Entity<Menu>().ToTable("menus", t => t.ExcludeFromMigrations());
        }
    }
}
