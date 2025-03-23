
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<RecipeEntity> GetAll();
    }
}