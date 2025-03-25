using RecipeBook.Common.Extension;
using RecipeBook.Repository;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddOpenApi();
services.AddDbContext<RecipeBookContext>();
services.AddTransient<IRepositoryManager, RepositoryManager>();
//services.AddHostedService<SeederService>();
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

app.MapGet("/", (ILogger<Program> logger, IRepositoryManager repoManager) =>
{
    logger.LogInformation("Hello World!");
    var asd = repoManager.CategoryRepository.GetAll();
    return string.Join(", ", "Hi");
});

app.Run();