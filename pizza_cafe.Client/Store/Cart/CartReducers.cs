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
    
        var existingItem = cart.CartItems.Find(item => item.Dish.Name == dish.Name);

        if (existingItem != null)
        {
            existingItem.Count += count;
            existingItem.Price += dish.Price * count;
        }
        else
        {
            cart.CartItems.Add(new CartItem() { Dish = dish, Count = count, Price = dish.Price * count });
        }

        cart.Price += dish.Price * count;

        return new CartState(cart);
    }

    [ReducerMethod]
    public static CartState ReduceRemoteFromCartAction(CartState state, CartAction.RemoveFromCartAction action)
    {
        var cart = new CartState(state).Cart; 

        var existingItemIndex = cart.CartItems.IndexOf(action.Dish);

        if (existingItemIndex != -1)
        {
            cart.Price -= cart.CartItems[existingItemIndex].Price;
            cart.CartItems.RemoveAt(existingItemIndex);
        }
        
        return new CartState(cart);
    }
}