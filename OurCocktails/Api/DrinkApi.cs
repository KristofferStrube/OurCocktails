using Microsoft.AspNetCore.Http.HttpResults;
using OurCocktails.Client.Models;
using OurCocktails.Client.Repositories;
using System.Runtime.CompilerServices;

namespace OurCocktails.Api;

public static class DrinkApi
{
    public static IEndpointRouteBuilder MapDrinkApi(this IEndpointRouteBuilder builder)
    {
        RouteGroupBuilder group = builder.MapGroup("/drink/");

        group.MapGet("/{url}", GetDrink);
        group.MapPost("/", CreateDrink);
        group.MapGet("/randomDescription", StreamRandomDrinkDescription);

        return builder;
    }

    public static async Task<Results<Ok<Drink>, NotFound<string>>> GetDrink(string url, IStorage storage)
    {
        Drink? result = await storage.GetDrink(url);

        if (result is null)
            return TypedResults.NotFound($"Could not find drink with url '{url}'.");

        return TypedResults.Ok(result);
    }

    public static async Task<Ok<Drink>> CreateDrink(CreateDrinkRequest request, IStorage storage)
    {
        Drink newDrink = request.MapToDrink();

        await storage.AddDrink(newDrink);

        return TypedResults.Ok(newDrink);
    }

    public static async Task<ServerSentEventsResult<string>> StreamRandomDrinkDescription(IStorage storage, CancellationToken cancellationToken)
    {
        Drink randomDrink = await storage.GetRandomDrink();

        async IAsyncEnumerable<string> DrinkDescription([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            yield return randomDrink.Name;
            foreach (string line in randomDrink.Description.Split("."))
            {
                await Task.Delay(1000, cancellationToken);
                yield return line.Trim();
            }
            foreach (string line in randomDrink.Recipe.Split("\n"))
            {
                await Task.Delay(1000, cancellationToken);
                yield return line.Trim();
            }
        }

        return TypedResults.ServerSentEvents(DrinkDescription(cancellationToken));
    }
}
