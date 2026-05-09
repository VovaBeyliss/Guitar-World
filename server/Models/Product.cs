namespace GuitarWorld.Models;

public class Product {
    public int Id { get; set; }
    public int Price { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Brand { get; set; } = null!;
}