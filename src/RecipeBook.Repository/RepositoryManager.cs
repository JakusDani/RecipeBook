using RecipeBook.Repository.Repositories;

namespace RecipeBook.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<ICategoryRepository> _lazyCategoryRepo;

    public RepositoryManager(RecipeBookContext context)
    {
        _lazyCategoryRepo = new(() => new CategoryRepository(context));
    }

    public ICategoryRepository CategoryRepository => _lazyCategoryRepo.Value;
}