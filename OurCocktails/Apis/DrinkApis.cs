using Microsoft.AspNetCore.Http.HttpResults;
using OurCocktails.Shared.Models;
using OurCocktails.Shared.Repositories;

namespace OurCocktails.Apis;

public static class DrinkApis
{
    public static IEndpointRouteBuilder MapDrinkApis(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/drink/");

        _ = group.MapGet("/{url}", GetDrink);

        return builder;
    }

    public static async Task<Results<Ok<Drink>, BadRequest<string>>> GetDrink(string url, IStorage storage)
    {
        Drink? result = await storage.GetDrink(url);

        return result is null
            ? TypedResults.BadRequest($"Could not find drink with url '{url}'.")
            : (Results<Ok<Drink>, BadRequest<string>>)TypedResults.Ok(result);
    }
}
