using System.ComponentModel.DataAnnotations;

namespace OurCocktails.Client.Models;

public class IngredientLine
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Ingredient Ingredient { get; set; } = default!;

    [Range(1, double.MaxValue, ErrorMessage = "You should have atleast 1 of each ingredient in the recipe.")]
    public decimal Amount { get; set; }

    [Required]
    public Unit Unit { get; set; }

    public static IngredientLine NewEmpty() => new()
    {
        Id = Guid.Empty,
        Ingredient = new()
        {
            Id = Guid.Empty,
            Name = "",
        },
        Amount = 1,
        Unit = Unit.Centiliter
    };
}
