using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

internal class ImagesRepository : IImagesRepository
{
    private readonly RecipeBookContext _context;

    public ImagesRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<ImagesEntity> GetAll()
    {
        return _context.Image.ToList();
    }
}