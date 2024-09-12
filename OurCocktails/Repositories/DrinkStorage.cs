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
                .ThenInclude(line => line.Family)
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

    private static List<Drink> drinks { get; set; } = [
        new() {
            Id = new Guid("9a06f8ee-6aa6-46aa-a94d-89e3a1950e73"),
            Url = "j34lg3",
            Name = "Gin & Tonic - simple",
            Summary = "A simply Gin & Tonic.",
            Description = "This is the most basic Gin & Tonic drink. You can garnish this with rosemary, cucumber, or almost any citrus fruit.",
            Recipe = "1. Pour 2-4 ice cubes in a glass.\n2. Pour over the gin.\n3. Pour in Tonic.\n4. Decorate with garnish if you have any.",
            Images = ["https://www.liquor.com/thmb/sYX_sTKUpyagRermLA31SMLF3-8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__liquor__2019__09__18090535__Gin-and-Tonic-720x720-recipe-c2e32c4cf53c4ed7a4de20af8e862a12.jpg"],
            Ingredients = [
                new () {
                    Id = new Guid("1718a279-bae9-4b18-90e7-5048a0bde7c6"),
                    Family = new() { Id = new Guid("6fded356-11c0-4376-b97a-436d6aaffa92"), Name = "Gin" },
                    Amount = 4,
                    Unit = Unit.Centiliter,
                },
                new () {
                    Id = new Guid("c2e2711a-00bf-4b46-b6ab-2f03e2280a76"),
                    Family = new() { Id = new Guid("a8a0f727-7b35-4fe6-ad92-932de4b75ff5"), Name = "Tonic" },
                    Amount = 8,
                    Unit = Unit.Centiliter,
                }
            ]
        },
        new() {
            Id = new Guid("2780489e-fd18-43c9-b868-3b0b437e32ee"),
            Url = "23d2n2",
            Name = "Daiquiri",
            Summary = "A heavy rum based drink.",
            Description = "Even thouh the drink is heavy in alcohol it doesn't taste like it because its balanced out by a lot of sour and sweet.",
            Recipe = "1. Pour in rum.\n2. Pour in freshly pressed lime juice.\n3. Pour in sugar sirup.\n4. Pour 3 ice cubes in a shaker.\n5. Shake for 2 minutes.\n6. Pour into class through sieve.",
            Images = ["https://assets.bacardicontenthub.com/transform/8178432e-721f-4c42-b075-7392a94434b6/Bacardi_Daiquiri_Headerbanner_Mobile_PBX?io=transform:fit,width:500,height:625&format=jpg&quality=75"],
            Ingredients = [
                new () {
                    Id = new Guid("acd60b4b-7506-4dc8-84be-af08493bfbe0"),
                    Family = new() { Id = new Guid("110cabcd-0ec4-48d1-8938-223b05c5e773"), Name = "Rum" },
                    Amount = 6,
                    Unit = Unit.Centiliter,
                },
                new () {
                    Id = new Guid("991f41d5-a40d-43b0-add9-2e46a015287a"),
                    Family = new() { Id = new Guid("79423f85-3135-40fc-a34f-31f5da3ceb0b"), Name = "Lime juice" },
                    Amount = 3,
                    Unit = Unit.Centiliter,
                },
                new () {
                    Id = new Guid("fadbbeaf-73e5-4f8b-be35-0f6fe7a6ea47"),
                    Family = new() { Id = new Guid("dede46f8-7317-4d0d-a761-2f5e99d50f49"), Name = "Sugar sirup" },
                    Amount = 3,
                    Unit = Unit.Centiliter,
                }
            ]
        }
    ];
}
