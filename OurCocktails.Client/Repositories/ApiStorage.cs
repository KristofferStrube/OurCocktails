using OurCocktails.Shared.Models;
using OurCocktails.Shared.Repositories;
using System.Net.Http.Json;

namespace OurCocktails.Client.Repositories;

public class ApiStorage(HttpClient httpClient) : IStorage
{
    public async Task<Drink?> GetDrink(string url)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"/drink/{url}/");

        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<Drink>()
            : null;
    }

    public Task<List<Drink>> GetDrinks()
    {
        throw new NotImplementedException();
    }
}
