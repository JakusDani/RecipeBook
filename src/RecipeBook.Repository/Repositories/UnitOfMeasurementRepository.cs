using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

internal class UnitOfMeasurementRepository : IUnitOfMeasurementRepository
{
    private readonly RecipeBookContext _context;

    public UnitOfMeasurementRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public IEnumerable<UnitOfMeasurementEntity> GetAll()
    {
        return _context.UnitOfMeasurement.ToList();
    }
}