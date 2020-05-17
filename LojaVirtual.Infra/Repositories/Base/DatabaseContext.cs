using Flunt.Notifications;
using LojaVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LojaVirtual.Infra.Repositories.Base
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=LojaVirtual; User ID=SA; Password=1qaz2wsx!");

                //optionsBuilder.UseSqlServer("Server=lojavirtual.db; Database=master; User ID=SA; Password=1qaz2wsx!S");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
