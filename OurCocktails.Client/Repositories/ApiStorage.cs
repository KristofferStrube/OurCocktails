using OurCocktails.Shared.Models;
using OurCocktails.Shared.Repositories;

namespace OurCocktails.Client.Repositories;

public class ApiStorage : IStorage
{
    public async Task<Drink?> GetDrink(string url)
    {
        throw new NotImplementedException();
    }

    public Task<List<Drink>> GetDrinks()
    {
        throw new NotImplementedException();
    }
}
