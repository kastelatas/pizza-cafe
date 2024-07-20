using System.Net.Http.Json;
using Fluxor;
using pizza_cafe.Shared.Models;

namespace pizza_cafe.Client.Store.Menu;

public class MenuEffects
{
    private readonly HttpClient Http;

    public MenuEffects(HttpClient http)
    {
        Http = http;
    }

    [EffectMethod]
    public async Task HandleFetchDataAction(MenuAction.FetchDataAction action, IDispatcher dispatcher)
    {
        var forecasts = await Http.GetFromJsonAsync<Dish[]>("menuData/menu.json");
        dispatcher.Dispatch(new MenuAction.FetchDataResultAction(forecasts));
    }
}