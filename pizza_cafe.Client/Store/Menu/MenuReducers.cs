using Fluxor;
using pizza_cafe.Shared.Models;
using pizza_cafe.Shared.Enums;

namespace pizza_cafe.Client.Store.Menu;

public class MenuReducers
{
    // [ReducerMethod]
    // public static MenuState ReduceAddToMenuAction(MenuState state, MenuAction.AddToMenuAction action)
    // {
    //     var dish = action.Dish;
    //     var existingItem = FindDishByName(state.Menu, dish.Name);
    //
    //     if (existingItem != null)
    //     {
    //         var categoryName = "";
    //         var category = state.Menu.Find(c => c.ContainsKey(categoryName));
    //         if (category != null)
    //         {
    //             category[categoryName].Add(dish);
    //         }
    //         else
    //         {
    //             Console.WriteLine($"Категория \"{categoryName}\" не найдена");
    //         }
    //
    //         return new MenuState(true, new List<Dictionary<string, List<Dish>>> { category });
    //     }
    //     else
    //     {
    //         return new MenuState(true, state.Menu);
    //     }
    // }

    // [ReducerMethod]
    // public static MenuState ReduceRemoveFromMenuAction(MenuState state, MenuAction.RemoveFromMenuAction action)
    // {
    //     var dishToRemove = action.Dish;
    //     var updatedMenu = new List<Dictionary<string, List<Dish>>>();
    //
    //     foreach (var category in state.Menu)
    //     {
    //         var updatedCategory = new Dictionary<string, List<Dish>>();
    //
    //         foreach (var item in category)
    //         {
    //             var updatedDishes = item.Value.Where(dish => dish.Name != dishToRemove.Name).ToList();
    //
    //             if (updatedDishes.Any())
    //             {
    //                 updatedCategory[item.Key] = updatedDishes;
    //             }
    //         }
    //
    //         if (updatedCategory.Any())
    //         {
    //             updatedMenu.Add(updatedCategory);
    //         }
    //     }
    //
    //     return new MenuState(true, updatedMenu);
    // }

    [ReducerMethod]
    public static MenuState ReduceFetchDataAction(MenuState state, MenuAction.FetchDataAction action) =>
        new(isLoading: true, menu: null);

    [ReducerMethod]
    public static MenuState ReduceFetchDataResultAction(MenuState state, MenuAction.FetchDataResultAction action)
    {
        var actionMenu = action.Menu;

        var dishes = new Dictionary<string, List<Dish>>();

        foreach (var dish in actionMenu)
        {
            var typeKey = dish.TypeOfDish.ToReadableString();
            if (!dishes.ContainsKey(typeKey))
            {
                dishes[typeKey] = new List<Dish>();
            }

            dishes[typeKey].Add(dish);
        }

        var menu = new List<Dictionary<string, List<Dish>>> { dishes };

        return new MenuState(false, menu);
    }


    private static Dish FindDishByName(List<Dictionary<string, List<Dish>>> menu, string dishName)
    {
        foreach (var category in menu)
        {
            foreach (var item in category)
            {
                var dish = item.Value.FirstOrDefault(d => d.Name.Equals(dishName, StringComparison.OrdinalIgnoreCase));
                if (dish != null)
                {
                    return dish;
                }
            }
        }

        return null;
    }
}