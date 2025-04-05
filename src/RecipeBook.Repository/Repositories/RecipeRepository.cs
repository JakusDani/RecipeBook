using Microsoft.EntityFrameworkCore;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

internal class RecipeRepository : IRecipeRepository
{
    private readonly RecipeBookContext _context;

    public RecipeRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<RecipeEntity> GetAll()
    {
        return _context.Recipe
            .Include(recipe => recipe.Category)
            .Include(recipe => recipe.Images)
            .Include(recipe => recipe.Ingredients)
                .ThenInclude(ingredient => ingredient.UnitOfMeasurement)
                .ThenInclude(unit => unit.MeasurementSystem)
            .ToList();
    }
}
