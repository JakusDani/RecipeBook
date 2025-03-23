using RecipeBook.Common.Extension;
using RecipeBook.Repository;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddOpenApi();
services.AddDbContext<RecipeBookContext>();
services.AddTransient<IUsersRepository, UsersRepository>();
builder.UseSerilogInWebApp();

var app = builder.Build();

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

app.MapGet("/", (ILogger<Program> logger, IUsersRepository userRepo) =>
{
    logger.LogInformation("Hello World!");
    return string.Join(", ", userRepo.GetAll());
});

app.Run();