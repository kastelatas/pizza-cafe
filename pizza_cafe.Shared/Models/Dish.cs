using pizza_cafe.Shared.Enums;

namespace pizza_cafe.Shared.Models;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public int Weight { get; set; }
    public int Count { get; set; }
    public TypeOfDish TypeOfDish { get; set; }
}