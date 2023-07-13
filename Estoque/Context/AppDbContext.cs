using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<CategoryStock> CategoriesStock { get; set; } 

        public DbSet<ProductsStock> ProductsStock { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            //categoryStock
            mb.Entity<CategoryStock>().HasKey(c => c.CategoryId);
            mb.Entity<CategoryStock>().Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            //ProductsStock
            mb.Entity<ProductsStock>().Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            mb.Entity<ProductsStock>().Property(c => c.Price)
                .HasMaxLength(100)
                .HasPrecision(12, 2)
                .IsRequired();
            mb.Entity<ProductsStock>().Property(c=>c.Stock)
                .HasMaxLength(100)
                .IsRequired();

            mb.Entity<CategoryStock>()
                 .HasMany(g => g.Products)
                 .WithOne(c => c.Category)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);
    
            mb.Entity<CategoryStock>().HasData(
                new CategoryStock
                {
                    CategoryId = 1,
                    Name = "Calcas "
                },
                new CategoryStock
                {
                    CategoryId = 2,
                    Name = "Acessorios "
                });
        }
    }
}
