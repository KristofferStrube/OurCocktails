using System.Text.Json.Serialization;

namespace OurCocktails.Shared.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Unit>))]
public enum Unit
{
    Deciliter,
    Centiliter,
    Milliliter,
    Gram,
    Pieces,
    Drops,
}

public static class UnitExtensions
{
    public static string ShortFormat(this Unit unit) => unit switch
    {
        Unit.Deciliter => "dL",
        Unit.Centiliter => "cL",
        Unit.Milliliter => "mL",
        Unit.Gram => "g",
        Unit.Pieces => "pieces",
        Unit.Drops => "drops",
        _ => throw new ArgumentException($"{nameof(Unit)} '{unit}' was not supported."),
    };
}