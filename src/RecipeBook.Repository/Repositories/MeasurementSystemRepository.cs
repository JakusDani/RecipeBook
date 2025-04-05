using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

internal class MeasurementSystemRepository : IMeasurementSystemRepository
{
    private readonly RecipeBookContext _context;

    public MeasurementSystemRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<MeasurementSystemEntity> GetAll()
    {
        return _context.MeasurementSystem.ToList();
    }
}