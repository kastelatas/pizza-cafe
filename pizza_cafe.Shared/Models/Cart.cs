namespace pizza_cafe.Shared.Models;

public class Cart
{
    public List<CartItem> CartItems { get; set; }
    public double Price { get; set; }
}