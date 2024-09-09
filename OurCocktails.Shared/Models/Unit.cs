namespace OurCocktails.Shared.Models;

public enum Unit
{
    Deciliter,
    Centiliter,
    Milliliter,
    Gram,
}

public static class UnitExtensions
{
    public static string ShortFormat(this Unit unit) => unit switch
    {
        Unit.Deciliter => "dL",
        Unit.Centiliter => "cL",
        Unit.Milliliter => "mL",
        Unit.Gram => "g",
        _ => throw new ArgumentException($"{nameof(Unit)} '{unit}' was not supported."),
    };
}