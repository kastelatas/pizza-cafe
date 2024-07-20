namespace pizza_cafe.Shared.Models;

public class CartItem
{
    public Dish Dish { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
}