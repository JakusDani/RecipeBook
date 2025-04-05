using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

public interface ICategoryRepository
{
    IEnumerable<CategoryEntity> GetAll();
}