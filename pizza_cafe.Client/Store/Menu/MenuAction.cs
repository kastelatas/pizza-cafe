using pizza_cafe.Shared.Models;

namespace pizza_cafe.Client.Store.Menu;

public class MenuAction
{
    public class AddToMenuAction
    {
        public Dish Dish { get; }

        public AddToMenuAction(Dish dish)
        {
            Dish = dish;
        }
    }

    public class RemoveFromMenuAction
    {
        public Dish Dish { get; }

        public RemoveFromMenuAction(Dish dish)
        {
            Dish = dish;
        }
    }

    public class FetchDataAction
    {
    }

    public class FetchDataResultAction
    {
        public IEnumerable<Dish> Menu { get; }

        public FetchDataResultAction(IEnumerable<Dish> menu)
        {
            Menu = menu;
        }
    }
}