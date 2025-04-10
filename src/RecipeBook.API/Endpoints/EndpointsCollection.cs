namespace RecipeBook.API.Endpoints;

public static class EndpointsCollection
{
    public static WebApplication UseEndpoints(this WebApplication app)
    {
        app.AddRecipeEndpoints();
        return app;
    }
}