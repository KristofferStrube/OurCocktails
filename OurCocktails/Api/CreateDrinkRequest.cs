using OurCocktails.Shared.Models;
using OurCocktails.Shared.Validations;

namespace OurCocktails.Api;

public class CreateDrinkRequest
{
    public required string Name { get; set; }
    public required string Summary { get; set; }
    public required string Description { get; set; }
    public required string Recipe { get; set; }
    public List<string> Images { get; set; } = [];

    [Size<IngredientLine>(MinLength: 1)]
    public List<IngredientLine> Ingredients { get; set; } = [];

    public Drink MapToDrink()
    {
        return new()
        {
            Name = Name,
            Description = Description,
            Recipe = Recipe,
            Summary = Summary,
            Images = Images,
            Ingredients = Ingredients,
        };
    }
}
