using FluentValidation;
using RecipeBook.API.Constants;
using RecipeBook.API.MiddleWares;
using RecipeBook.Common.Models.Requests;
using RecipeBook.Repository;

namespace RecipeBook.API.Endpoints;

public static class RecipeCollection
{
    public static WebApplication AddRecipeEndpoints(this WebApplication app)
    {
        app.GetAll();
        return app;
    }

    private static WebApplication GetAll(this WebApplication app)
    {
        app.MapGet(EndpointConst.Recipe.GetAll,
            (ILogger<Program> logger,
            IRepositoryManager repoManager,
            IValidator<RecipeRequest> validator) =>
        {
            logger.LogInformation("Select all record...");
            var allRecipe = repoManager.RecipeRepository.GetAll();
            return string.Join(", ", allRecipe.Select(x => x.Name));

        }).AddEndpointFilter<RecipeValidatorFilter<RecipeRequest>>();

        return app;
    }
}