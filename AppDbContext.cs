using Microsoft.EntityFrameworkCore;
using SouqAlSalam.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouqAlSalam.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
            public DbSet<User> Users { get; set; }
            public DbSet<Store> Stores { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<ProductImage> ProductImages { get; set; }
            public DbSet<Cart> Carts { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
            public DbSet<Review> Reviews { get; set; }
            public DbSet<ReviewImage> ReviewImages { get; set; }
            public DbSet<Favorite> Favorites { get; set; }
            public DbSet<Address> Addresses { get; set; }
            //public DbSet<CartItem> CartItems { get; set; }
            public DbSet<ProductVariant> ProductVariants { get; set; }
            public DbSet<FollowedStores> FollowStores { get; set; }
    }
}
