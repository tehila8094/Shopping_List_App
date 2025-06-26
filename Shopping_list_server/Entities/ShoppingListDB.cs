using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ShoppingListDB : DbContext
    {
        public ShoppingListDB(DbContextOptions<ShoppingListDB> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).IsRequired();

                // Index for better performance
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Quantity).HasDefaultValueSql("1");
                entity.Property(e => e.Unit).HasMaxLength(50);
                entity.Property(e => e.IsCompleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).IsRequired();

                // Foreign key relationship
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade); // Delete products when category is deleted

                // Indexes for better performance
                entity.HasIndex(e => e.CategoryId);
                entity.HasIndex(e => e.Name);
                entity.HasIndex(e => e.IsCompleted);
            });

            
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "ירקות ופירות", Description = "מוצרים טריים", CreatedAt = DateTime.UtcNow },
                new Category { Id = 2, Name = "גבינות", Description = "מוצרי חלב וביצים", CreatedAt = DateTime.UtcNow },
                new Category { Id = 3, Name = "בשר ודגים", Description = "חלבונים מהחי", CreatedAt = DateTime.UtcNow },
                new Category { Id = 4, Name = "מאפים", Description = "פחמימות ודגנים", CreatedAt = DateTime.UtcNow },
                new Category { Id = 5, Name = "מוצריניקיון", Description = "מוצרי ניקיון ואמבטיה", CreatedAt = DateTime.UtcNow }
            );

            //// Seed Products
            //modelBuilder.Entity<Product>().HasData(
            //    new Product { Id = 1, Name = "תפוחים", Price = 12.90m, Quantity = 2, Unit = "ק\"ג", CategoryId = 1, CreatedAt = DateTime.UtcNow },
            //    new Product { Id = 2, Name = "בננות", Price = 8.50m, Quantity = 1, Unit = "ק\"ג", CategoryId = 1, CreatedAt = DateTime.UtcNow },
            //    new Product { Id = 3, Name = "חלב", Price = 6.90m, Quantity = 2, Unit = "ליטר", CategoryId = 2, CreatedAt = DateTime.UtcNow },
            //    new Product { Id = 4, Name = "ביצים", Price = 18.90m, Quantity = 1, Unit = "מארז 12", CategoryId = 2, CreatedAt = DateTime.UtcNow },
            //    new Product { Id = 5, Name = "חזה עוף", Price = 35.90m, Quantity = 1, Unit = "ק\"ג", CategoryId = 3, CreatedAt = DateTime.UtcNow }
            //);
        }
    }
}
