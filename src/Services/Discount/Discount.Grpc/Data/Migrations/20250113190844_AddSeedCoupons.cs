using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.Grpc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedCoupons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[,]
                {
                    { 1, 15, "Save on premium sound quality with noise cancellation.", "Wireless Bluetooth Earbuds" },
                    { 2, 10, "Enjoy a discount on sustainably sourced coffee.", "Organic Coffee Beans" },
                    { 3, 20, "Get a discount on 24/7 home monitoring.", "Smart Home Security Camera" },
                    { 4, 12, "Perfect your poses with this eco-friendly mat.", "Yoga Mat with Alignment Lines" },
                    { 5, 25, "Cook meals faster with this versatile kitchen gadget.", "Electric Pressure Cooker" },
                    { 6, 18, "Illuminate your workspace and charge your phone simultaneously.", "LED Desk Lamp with Wireless Charger" },
                    { 7, 30, "Crafted from genuine leather, slim and durable.", "Men's Leather Wallet" },
                    { 8, 22, "Lightweight and breathable for maximum comfort.", "Women's Running Shoes" },
                    { 9, 14, "Take your music anywhere with this waterproof speaker.", "Portable Bluetooth Speaker" },
                    { 10, 35, "Breathe cleaner air with this HEPA filter purifier.", "Air Purifier for Home" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
