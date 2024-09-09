namespace OurCocktails.Shared.Models;

public class Ingredient
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Ingredient> FamilyHierarchy { get; set; } = [];
    public string? Description { get; set; }
}
