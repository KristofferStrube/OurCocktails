namespace OurCocktails.Shared.Models;

public class IngredientLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Ingredient Ingredient { get; set; }
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
