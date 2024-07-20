using Fluxor;
using pizza_cafe.Shared.Models;
using SharedCart = pizza_cafe.Shared.Models.Cart;

namespace pizza_cafe.Client.Store.Cart;

[FeatureState(CreateInitialStateMethodName = nameof(CreateInitialState))]
public class CartState
{
    public SharedCart Cart { get; }

    public CartState(SharedCart cart)
    {
        Cart = cart;
    }

    private static CartState CreateInitialState()
    {
        return new CartState(new SharedCart() { CartItems = new List<CartItem>(), Price = 0 });
    }
    
    public CartState(CartState original)
    {
        SharedCart cartCopy = new SharedCart()
        {
            CartItems = new List<CartItem>(original.Cart.CartItems),
            Price = original.Cart.Price 
        };

        Cart = cartCopy;
    }
}