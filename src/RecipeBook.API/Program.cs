using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RecipeBook.API.MiddleWares;
using RecipeBook.API.Validations;
using RecipeBook.Common.Extension;
using RecipeBook.Common.Models.Requests;
using RecipeBook.Repository;
using RecipeBook.Repository.Extensions;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration["Database:ConnectionString"];

services.AddOpenApi();
services.AddDbContext<RecipeBookContext>(optionsBuilder =>
    optionsBuilder.UseSqlite(connectionString)
            .UseAsyncSeeding(async (context, _, cts) =>
            {
                context.AddCategoriesIfNotExists();
                context.AddMeasurementSystemIfNotExists();
                context.AddUnitOfMeasurementIfNotExists();
                await context.SaveChangesAsync(cts);
            }));

services.AddTransient<IRepositoryManager, RepositoryManager>();
builder.Services.AddValidatorsFromAssemblyContaining<RecipeValidator>();
builder.UseSerilogInWebApp();

var app = builder.Build();

await using (var serviceScope = app.Services.CreateAsyncScope())
await using (var context = serviceScope.ServiceProvider.GetRequiredService<RecipeBookContext>())
{
    await context.Database.EnsureCreatedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.MapGet("/", (ILogger<Program> logger,
    IRepositoryManager repoManager,
    IValidator<RecipeRequest> validator) =>
{
    logger.LogInformation("Select all record...");
    var allRecipe = repoManager.RecipeRepository.GetAll();
    return string.Join(", ", allRecipe.Select(x => x.Name));
}).AddEndpointFilter<RecipeValidatorFilter<RecipeRequest>>();

app.Run();