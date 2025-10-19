using System.ComponentModel.DataAnnotations;

namespace OurCocktails.Shared.Models;

public class IngredientLine
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required Ingredient Ingredient { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "You should have atleast 1 of each ingredient in the recipe.")]
    public decimal Amount { get; set; }
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
