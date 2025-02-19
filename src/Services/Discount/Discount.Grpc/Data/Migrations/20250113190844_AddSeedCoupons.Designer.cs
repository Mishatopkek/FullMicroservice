﻿// <auto-generated />
using Discount.Grpc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Discount.Grpc.Data.Migrations
{
    [DbContext(typeof(DiscountContext))]
    [Migration("20250113190844_AddSeedCoupons")]
    partial class AddSeedCoupons
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Discount.Grpc.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 15,
                            Description = "Save on premium sound quality with noise cancellation.",
                            ProductName = "Wireless Bluetooth Earbuds"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 10,
                            Description = "Enjoy a discount on sustainably sourced coffee.",
                            ProductName = "Organic Coffee Beans"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 20,
                            Description = "Get a discount on 24/7 home monitoring.",
                            ProductName = "Smart Home Security Camera"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 12,
                            Description = "Perfect your poses with this eco-friendly mat.",
                            ProductName = "Yoga Mat with Alignment Lines"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 25,
                            Description = "Cook meals faster with this versatile kitchen gadget.",
                            ProductName = "Electric Pressure Cooker"
                        },
                        new
                        {
                            Id = 6,
                            Amount = 18,
                            Description = "Illuminate your workspace and charge your phone simultaneously.",
                            ProductName = "LED Desk Lamp with Wireless Charger"
                        },
                        new
                        {
                            Id = 7,
                            Amount = 30,
                            Description = "Crafted from genuine leather, slim and durable.",
                            ProductName = "Men's Leather Wallet"
                        },
                        new
                        {
                            Id = 8,
                            Amount = 22,
                            Description = "Lightweight and breathable for maximum comfort.",
                            ProductName = "Women's Running Shoes"
                        },
                        new
                        {
                            Id = 9,
                            Amount = 14,
                            Description = "Take your music anywhere with this waterproof speaker.",
                            ProductName = "Portable Bluetooth Speaker"
                        },
                        new
                        {
                            Id = 10,
                            Amount = 35,
                            Description = "Breathe cleaner air with this HEPA filter purifier.",
                            ProductName = "Air Purifier for Home"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
