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
                .ThenInclude(i => i.Ingredient)
            .FirstOrDefaultAsync(d => d.Url == url);
    }

    public async Task<Drink> GetRandomDrink()
    {
        return await context.Drinks
            .OrderBy(d => EF.Functions.Random())
            .Include(d => d.Ingredients)
                .ThenInclude(i => i.Ingredient)
            .FirstAsync();
    }
 
    public async Task AddDrink(Drink drink)
    {
        drink.Id = Guid.NewGuid();
        context.Add(drink);
        await context.SaveChangesAsync();
    }

    public async Task UpdateDrink(Drink drink)
    {
        context.Drinks.Update(drink);
        await context.SaveChangesAsync();
    }

    public async Task DeleteDrink(Drink drink)
    {
        context.Drinks.Remove(drink);
        await context.SaveChangesAsync();
    }
}
