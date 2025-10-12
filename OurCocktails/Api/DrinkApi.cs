using Microsoft.AspNetCore.Http.HttpResults;
using OurCocktails.Shared.Models;
using OurCocktails.Shared.Repositories;

namespace OurCocktails.Api;

public static class DrinkApi
{
    public static IEndpointRouteBuilder MapDrinkApi(this IEndpointRouteBuilder builder)
    {
        RouteGroupBuilder group = builder.MapGroup("/drink/");

        group.MapGet("/{url}", GetDrink);

        return builder;
    }

    public static async Task<Results<Ok<Drink>, NotFound<string>>> GetDrink(string url, IStorage storage)
    {
        Drink? result = await storage.GetDrink(url);

        if (result is null)
            return TypedResults.NotFound($"Could not find drink with url '{url}'.");

        return TypedResults.Ok(result);
    }

    public static async Task<>
}
