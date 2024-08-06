namespace pizza_cafe.Shared.Models;

public class CartItem
{
    public Dish Dish { get; set; }
    public double Count { get; set; }
    public double Price { get; set; }
}