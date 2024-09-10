namespace OurCocktails.Shared.Models;

public class Drink
{
    public required Guid Id { get; set; }
    public required string Url { get; set; }
    public required string Name { get; set; }
    public string NameNormalized => Name.ToLower().Replace(" - ", "-").Replace(" ", "-").Replace(".", "").Replace("&", "and");
    public required string Summary { get; set; }
    public required string Description { get; set; }
    public required string Recipe { get; set; }
    public string RecipeAsHtml => Recipe.Replace("\n", "<br />");
    public List<string> Images { get; set; } = [];
    public List<IngredientLine> Ingredients { get; set; } = [];

    public static Drink NewEmpty() => new()
    {
        Id = Guid.NewGuid(),
        Url = Guid.NewGuid().ToString()[..6],
        Name = "",
        Summary = "",
        Description = "",
        Recipe = "",
        Ingredients = []
    };
}
