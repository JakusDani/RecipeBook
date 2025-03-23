using RecipeBook.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly RecipeBookContext _context;

    public UsersRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<RecipeEntity> GetAll()
    {
        return [new RecipeEntity()];
    }
}