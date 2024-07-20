using pizza_cafe.Shared.Models;

namespace pizza_cafe.Client.Store.Cart;

public class CartAction
{

    public class AddToCartAction
    {
        public Dish Dish { get; }
        public int Count { get; }

        public AddToCartAction(Dish dish, int count)
        {
            Dish = dish;
            Count = count;
        }
    }

    public class RemoveFromCartAction
    {
        public CartItem Dish { get; }

        public RemoveFromCartAction(CartItem dish)
        {
            Dish = dish;
        }
    }
   
        
}