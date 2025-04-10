using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RecipeBook.API.Endpoints;
using RecipeBook.API.Validators;
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

if (app.Environment.IsDevelopment())
{
    await using (var serviceScope = app.Services.CreateAsyncScope())
    await using (var context = serviceScope.ServiceProvider.GetRequiredService<RecipeBookContext>())
    {
        await context.Database.EnsureCreatedAsync();
    }

    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseEndpoints();

app.Run();