using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OurCocktails.Client.Repositories;
using OurCocktails.Shared.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IStorage, ApiStorage>();

await builder.Build().RunAsync();