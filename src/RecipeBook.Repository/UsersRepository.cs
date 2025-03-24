using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly RecipeBookContext _context;

    public UsersRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<CategoryEntity> GetAll()
    {
        return _context.Category.ToList();
    }
}