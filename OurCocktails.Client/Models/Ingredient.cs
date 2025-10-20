using System.ComponentModel.DataAnnotations;

namespace OurCocktails.Client.Models;

public class Ingredient
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "The ingredient name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The ingredient name must be between 2 and 100 characters.")]
    public string Name { get; set; } = default!;
    public List<Ingredient> FamilyHierarchy { get; set; } = [];
    public string? Description { get; set; }
}
