namespace OurCocktails.Shared.Models;

public class Ingredient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public List<Ingredient> FamilyHierarchy { get; set; } = [];
    public string? Description { get; set; }
}
