using OurCocktails.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace OurCocktails.Api;

public class CreateDrinkRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The drink name must be between 2 and 100 characters.")]
    public string Name { get; set; } = default!;

    [Required]
    public string Summary { get; set; } = default!;

    [Required]
    public string Description { get; set; } = default!;

    [Required]
    public string Recipe { get; set; } = default!;

    public List<string> Images { get; set; } = [];

    [MinLength(1, ErrorMessage = "A drink should have at least 1 ingredient.")]
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
