using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OurCocktails.Shared.Models;

namespace OurCocktails.DataBase;

public class OurCocktailsContext(DbContextOptions<OurCocktailsContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Drink> Drinks => Set<Drink>();
    public DbSet<IngredientLine> IngredientLines => Set<IngredientLine>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
}
