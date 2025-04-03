using RecipeBook.Repository.Repositories;

namespace RecipeBook.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<ICategoryRepository> _lazyCategoryRepo;
    private readonly Lazy<IRecipeRepository> _lazyRecipeRepo;
    private readonly Lazy<IIngredientRepository> _lazyIngredientRepo;
    private readonly Lazy<IUnitOfMeasurementRepository> _lazyUnitOfMeasurementRepo;

    public RepositoryManager(RecipeBookContext context)
    {
        _lazyCategoryRepo = new(() => new CategoryRepository(context));
        _lazyRecipeRepo = new(() => new RecipeRepository(context));
        _lazyIngredientRepo = new(() => new IngredientRepository(context));
        _lazyUnitOfMeasurementRepo = new(() => new UnitOfMeasurementRepository(context));
    }

    public ICategoryRepository CategoryRepository => _lazyCategoryRepo.Value;
    public IRecipeRepository RecipeRepository => _lazyRecipeRepo.Value;
    public IIngredientRepository IngredientRepository => _lazyIngredientRepo.Value;
    public IUnitOfMeasurementRepository UnitOfMeasurementRepository => _lazyUnitOfMeasurementRepo.Value;
}