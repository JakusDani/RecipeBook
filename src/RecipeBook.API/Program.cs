using Microsoft.EntityFrameworkCore;
using RecipeBook.Common.Extension;
using RecipeBook.Repository;
using RecipeBook.Repository.Extensions;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration["Database:ConnectionString"];

services.AddOpenApi();
services.AddDbContext<RecipeBookContext>(optionsBuilder =>
    optionsBuilder.UseSqlite($"Data Source={connectionString}")
            .UseAsyncSeeding(async (context, _, cts) =>
            {
                context.AddCategoriesIfNotExists();
                context.AddMeasurementSystemIfNotExists();
                await context.SaveChangesAsync(cts);
            }));

services.AddTransient<IRepositoryManager, RepositoryManager>();
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

app.MapGet("/", (ILogger<Program> logger, IRepositoryManager repoManager) =>
{
    logger.LogInformation("Select all record...");
    var all = repoManager.CategoryRepository.GetAll();
    return string.Join(", ", all.Select(x => x.Name));
});

app.Run();