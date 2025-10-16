using Microsoft.EntityFrameworkCore;
using OurCocktails.Api;
using OurCocktails.Components;
using OurCocktails.DataBase;
using OurCocktails.Repositories;
using OurCocktails.Shared.Repositories;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IStorage, DrinkStorage>();
builder.Services.AddSqlite<OurCocktailsContext>("Data Source=.db/ourcocktails.db");
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    OurCocktailsContext context = scope.ServiceProvider.GetRequiredService<OurCocktailsContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapStaticAssets();
app.UseAntiforgery();

app.MapGroup("/api/").MapDrinkApi();
app.MapOpenApi();
app.MapScalarApiReference();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(OurCocktails.Client._Imports).Assembly);

app.Run();
