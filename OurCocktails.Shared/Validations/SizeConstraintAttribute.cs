using System.ComponentModel.DataAnnotations;

namespace OurCocktails.Shared.Validations;

public class SizeAttribute<T>(int MinLength) : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not List<T> list)
            throw new NotSupportedException($"Attribute {nameof(SizeAttribute<T>)} is use on a property that is not a List");

        if (list.Count < MinLength)
        {
            return false;
        }

        return true;
    }
}
