using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

public interface IUnitOfMeasurementRepository
{
    IEnumerable<UnitOfMeasurementEntity> GetAll();
}