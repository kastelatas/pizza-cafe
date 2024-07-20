using System.Net.Http.Json;
using Microsoft.JSInterop;
using pizza_cafe.Shared.Models;

namespace pizza_cafe.Client.Services;

public class WordTableService(HttpClient httpClient, IJSRuntime jsRuntime)
{
    private const string Url = "https://api.pizza-cafe.store";
    private const string GEMERATE_WORD_URI = "api/Word/Generate";
    public async Task GenerateWord(Cart cart, string fileName)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync($"{Url}/{GEMERATE_WORD_URI}?fileName={fileName}", cart);

            var fileBytes = await response.Content.ReadAsByteArrayAsync();

            await jsRuntime.InvokeVoidAsync("saveAsFile", $"{fileName}.docx", Convert.ToBase64String(fileBytes));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task Init()
    {
        try
        {
            var response = await httpClient.GetAsync($"{Url}/api/Word/Init");
            
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}