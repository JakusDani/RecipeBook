using RecipeBook.Common.Enumeration;
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

    public async Task InitCategories()
    {
        var categories = _context.Category.Select(cat => cat.Id).ToList();
        var categoryEnums = Enum.GetValues<Categories>()
            .Select(item => new CategoryEntity
            {
                Id = (int)item,
                Name = item.ToString(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            })
            .Where(x => categories.Contains(x.Id) == false)
            .ToList();

        _context.Category.AddRange(categoryEnums);
        await _context.SaveChangesAsync();
    }
}