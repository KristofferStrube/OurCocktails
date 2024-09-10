using Microsoft.EntityFrameworkCore;
using OurCocktails.Shared.Models;

namespace OurCocktails.DataBase;

public class OurCocktailsContext(DbContextOptions<OurCocktailsContext> options) : DbContext(options)
{
    public DbSet<Drink> Drinks => Set<Drink>();
    public DbSet<IngredientLine> IngredientLines => Set<IngredientLine>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Family> Families => Set<Family>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
