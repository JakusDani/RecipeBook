using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

internal class IngredientRepository : IIngredientRepository
{
    private readonly RecipeBookContext _context;

    public IngredientRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<IngredientsEntity> GetAll()
    {
        return _context.Ingredient.ToList();
    }
}