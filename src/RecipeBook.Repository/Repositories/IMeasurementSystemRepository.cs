using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

public interface IMeasurementSystemRepository
{
    IEnumerable<MeasurementSystemEntity> GetAll();
}