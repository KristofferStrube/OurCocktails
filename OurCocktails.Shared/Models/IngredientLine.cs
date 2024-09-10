namespace OurCocktails.Shared.Models;

public class IngredientLine
{
    public required Guid Id { get; set; }
    public Ingredient? Ingredient { get; set; }
    public Family? Family { get; set; }
    public decimal Amount { get; set; }
    public Unit Unit { get; set; }

    public static IngredientLine NewEmpty() => new()
    {
        Id = Guid.Empty,
        Amount = 1,
        Unit = Unit.Centiliter
    };
}
