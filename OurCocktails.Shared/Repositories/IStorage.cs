using OurCocktails.Shared.Models;

namespace OurCocktails.Shared.Repositories;

public interface IStorage
{
    public Task<List<Drink>> GetDrinks();
    public Task<Drink?> GetDrink(string url);
    public Task AddDrink(Drink drink);
    public Task UpdateDrink(Drink drink);
}
