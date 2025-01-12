namespace Basket.Api.Models;

public class ShoppingCardItem
{
    public int Quantity { get; set; }
    public string Color { get; set; } = null!;
    public decimal Price { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
}