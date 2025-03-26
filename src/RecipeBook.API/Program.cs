using Microsoft.EntityFrameworkCore;
using RecipeBook.Common.Enumeration;
using RecipeBook.Common.Extension;
using RecipeBook.Repository;
using RecipeBook.Repository.Entities;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddOpenApi();
services.AddDbContext<RecipeBookContext>(optionsBuilder =>
    optionsBuilder.UseSqlite("My little Secret ;)")
            .UseAsyncSeeding(async (context, _, cts) =>
            {
                var categoriesToSeed = Enum.GetValues<Categories>()
                    .Select(item => new CategoryEntity
                    {
                        Id = (int)item,
                        Name = item.ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }).ToList();

                context.Set<CategoryEntity>()
                .AddRange(categoriesToSeed);

                await context.SaveChangesAsync();
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
    return string.Join(", ", all);
});

app.Run();