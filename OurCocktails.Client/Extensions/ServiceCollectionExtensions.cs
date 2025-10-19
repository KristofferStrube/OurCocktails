namespace OurCocktails.Client.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection collection)
    {
        public IServiceCollection AddValidationForTypesInClient()
        {
            return collection.AddValidation();
        }
    }
}
