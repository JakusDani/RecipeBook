using RecipeBook.Repository.Repositories;

namespace RecipeBook.Repository
{
    public interface IRepositoryManager
    {
        ICategoryRepository CategoryRepository { get; }
    }
}