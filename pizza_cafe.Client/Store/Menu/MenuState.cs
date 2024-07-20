using Fluxor;
using pizza_cafe.Shared.Models;
using pizza_cafe.Shared.Enums;

namespace pizza_cafe.Client.Store.Menu
{
    [FeatureState(CreateInitialStateMethodName = nameof(CreateInitialState))]
    public class MenuState
    {
        public bool IsLoading { get; }
        public List<Dictionary<string, List<Dish>>> Menu { get; }

        public MenuState(bool isLoading,List<Dictionary<string, List<Dish>>> menu)
        {
            IsLoading = isLoading;
            Menu = menu ?? new List<Dictionary<string, List<Dish>>>();
        }

        public MenuState(List<Dictionary<string, List<Dish>>> menu)
        {
            Menu = menu ?? new List<Dictionary<string, List<Dish>>>();
        }

        private static MenuState CreateInitialState()
        {
            return new MenuState(new List<Dictionary<string, List<Dish>>>());
        }
    }
}