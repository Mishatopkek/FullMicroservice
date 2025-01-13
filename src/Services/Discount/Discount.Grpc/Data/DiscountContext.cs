using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = 1, ProductName = "Wireless Bluetooth Earbuds",
                Description = "Save on premium sound quality with noise cancellation.", Amount = 15
            },
            new Coupon
            {
                Id = 2, ProductName = "Organic Coffee Beans",
                Description = "Enjoy a discount on sustainably sourced coffee.", Amount = 10
            },
            new Coupon
            {
                Id = 3, ProductName = "Smart Home Security Camera",
                Description = "Get a discount on 24/7 home monitoring.", Amount = 20
            },
            new Coupon
            {
                Id = 4, ProductName = "Yoga Mat with Alignment Lines",
                Description = "Perfect your poses with this eco-friendly mat.", Amount = 12
            },
            new Coupon
            {
                Id = 5, ProductName = "Electric Pressure Cooker",
                Description = "Cook meals faster with this versatile kitchen gadget.", Amount = 25
            },
            new Coupon
            {
                Id = 6, ProductName = "LED Desk Lamp with Wireless Charger",
                Description = "Illuminate your workspace and charge your phone simultaneously.", Amount = 18
            },
            new Coupon
            {
                Id = 7, ProductName = "Men's Leather Wallet",
                Description = "Crafted from genuine leather, slim and durable.", Amount = 30
            },
            new Coupon
            {
                Id = 8, ProductName = "Women's Running Shoes",
                Description = "Lightweight and breathable for maximum comfort.", Amount = 22
            },
            new Coupon
            {
                Id = 9, ProductName = "Portable Bluetooth Speaker",
                Description = "Take your music anywhere with this waterproof speaker.", Amount = 14
            },
            new Coupon
            {
                Id = 10, ProductName = "Air Purifier for Home",
                Description = "Breathe cleaner air with this HEPA filter purifier.", Amount = 35
            }
        );
    }
}