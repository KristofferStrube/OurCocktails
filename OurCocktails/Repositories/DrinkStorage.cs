using Microsoft.EntityFrameworkCore;
using OurCocktails.DataBase;
using OurCocktails.Shared.Models;
using OurCocktails.Shared.Repositories;

namespace OurCocktails.Repositories;

public class DrinkStorage(OurCocktailsContext context) : IStorage
{
    public async Task<List<Drink>> GetDrinks()
    {
        return await context.Drinks.ToListAsync();
    }
    public async Task<Drink?> GetDrink(string url)
    {
        return await context.Drinks
            .Include(d => d.Ingredients)
            .FirstOrDefaultAsync(d => d.Url == url);
    }

    public async Task AddDrink(Drink drink)
    {
        context.Add(drink);
        await context.SaveChangesAsync();
    }

    public async Task UpdateDrink(Drink drink)
    {
        context.Drinks.Update(drink);
        await context.SaveChangesAsync();
    }
}
