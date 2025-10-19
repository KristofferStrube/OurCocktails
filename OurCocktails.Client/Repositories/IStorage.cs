using OurCocktails.Shared.Models;

namespace OurCocktails.Shared.Repositories;

public interface IStorage
{
    public Task<List<Drink>> GetDrinks();
    public Task<Drink?> GetDrink(string url);
    public Task<Drink> GetRandomDrink();
    public Task AddDrink(Drink drink);
    public Task UpdateDrink(Drink drink);
    public Task DeleteDrink(Drink drink);
}
