using RecipeBook.Repository.Repositories;

namespace RecipeBook.Repository;

public interface IRepositoryManager
{
    ICategoryRepository CategoryRepository { get; }
    IRecipeRepository RecipeRepository { get; }
    IIngredientRepository IngredientRepository { get; }
    IUnitOfMeasurementRepository UnitOfMeasurementRepository { get; }
}