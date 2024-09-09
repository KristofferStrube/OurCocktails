namespace OurCocktails.Shared.Models;

public class Family
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Family> Ancestors { get; set; }
    public string? Description { get; set; }
}
