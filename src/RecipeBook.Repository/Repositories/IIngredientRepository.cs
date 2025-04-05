using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

public interface IIngredientRepository
{
    IEnumerable<IngredientsEntity> GetAll();
}