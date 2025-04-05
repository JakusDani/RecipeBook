using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

internal class CategoryRepository : ICategoryRepository
{
    private readonly RecipeBookContext _context;

    public CategoryRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<CategoryEntity> GetAll()
    {
        return _context.Category.ToList();
    }
}