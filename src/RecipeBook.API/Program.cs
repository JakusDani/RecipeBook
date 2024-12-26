using RecipeBook.Common.Extension;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddOpenApi();
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

app.MapGet("/", (ILogger<Program> logger) =>
{
    logger.LogInformation("Hello World!");
    return "OK";
});

app.Run();