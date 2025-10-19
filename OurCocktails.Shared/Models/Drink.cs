using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace OurCocktails.Shared.Models;

public class Drink
{
    /// <summary>
    /// The id of the drink.
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;

    /// <summary>
    /// The URL part that can be used to link to the drink
    /// </summary>
    [JsonIgnore]
    public string Url { get; set; } = Guid.NewGuid().ToString()[..6];

    /// <summary>
    /// The name of the drink
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// A nornalized name that can be shown as a part of the URL.
    /// </summary>
    [JsonIgnore]
    public string NameNormalized => UrlEncoder.Default.Encode(Name.ToLower().Replace(" - ", "-").Replace(" ", "-").Replace(".", "").Replace("&", "and"));
    
    /// <summary>
    /// A short summary of the drink that will be shown in the drink card.
    /// </summary>
    public required string Summary { get; set; }

    /// <summary>
    /// A longer description of the drink. On the drink details page this will be prepended by the summary.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// The recipe for the drink. This text can include line-breaks: '\n'.
    /// </summary>
    public required string Recipe { get; set; }

    /// <summary>
    /// One or more images of the drink. Currently it only uses the first image if there are multiple.
    /// </summary>
    public List<string> Images { get; set; } = [];

    /// <summary>
    /// The ingredients for the drink.
    /// </summary>
    [MinLength(1, ErrorMessage = "A drink should have at least 1 ingredient.")]
    public List<IngredientLine> Ingredients { get; set; } = [];

    public static Drink NewEmpty() => new()
    {
        Name = "",
        Summary = "",
        Description = "",
        Recipe = ""
    };
}
