using OurCocktails.Shared.Validations;
using System.Text.Json.Serialization;

namespace OurCocktails.Shared.Models;

public class Drink
{
    public Guid Id { get; set; } = Guid.Empty;

    [JsonIgnore]
    public string Url { get; set; } = Guid.NewGuid().ToString()[..6];
    public required string Name { get; set; }

    [JsonIgnore]
    public string NameNormalized => Name.ToLower().Replace(" - ", "-").Replace(" ", "-").Replace(".", "").Replace("&", "and");
    public required string Summary { get; set; }
    public required string Description { get; set; }
    public required string Recipe { get; set; }

    [JsonIgnore]
    public string RecipeAsHtml => Recipe.Replace("\n", "<br />");
    public List<string> Images { get; set; } = [];

    [Size<IngredientLine>(MinLength: 1)]
    public List<IngredientLine> Ingredients { get; set; } = [];

    public static Drink NewEmpty() => new()
    {
        Name = "",
        Summary = "",
        Description = "",
        Recipe = "",
        Ingredients = []
    };
}
