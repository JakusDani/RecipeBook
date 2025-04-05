using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

public interface IRecipeRepository
{
    IEnumerable<RecipeEntity> GetAll();
}