using Fluxor;
using pizza_cafe.Shared.Models;

namespace pizza_cafe.Client.Store.Cart;

public static class CartReducers
{
    [ReducerMethod]
    public static CartState ReduceAddToCartAction(CartState state, CartAction.AddToCartAction action)
    {
        var dish = action.Dish;
        var count = action.Count;
        var cart = new CartState(state).Cart;  

        
        var existingItem = state.Cart.CartItems.Find(item => item.Dish.Name == dish.Name);

        if (existingItem != null)
        {
            existingItem.Count += count;
            existingItem.Price += dish.Price;
            cart.Price += dish.Price;
        }
        else
        {
            cart.CartItems.Add(new CartItem() { Dish = dish, Count = count, Price = dish.Price});
            cart.Price += dish.Price;
        }

        return new CartState(cart);
    }

    [ReducerMethod]
    public static CartState ReduceRemoteFromCartAction(CartState state, CartAction.RemoveFromCartAction action)
    {
        var cart = new CartState(state).Cart;

        var existingItemIndex = cart.CartItems.IndexOf(action.Dish);

        if (existingItemIndex != -1)
        {
            cart.CartItems.RemoveAt(existingItemIndex);
        }
        
        return new CartState(cart);
    }
}