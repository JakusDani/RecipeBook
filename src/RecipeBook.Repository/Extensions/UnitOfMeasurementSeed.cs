using Microsoft.EntityFrameworkCore;
using RecipeBook.Common.Enumeration;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Extensions;

public static class UnitOfMeasurementSeed
{
    public static DbContext AddUnitOfMeasurementIfNotExists(this DbContext context)
    {
        context.Set<UnitOfMeasurementEntity>()
            .AddRange(InitEntities());
        return context;
    }

    private static List<UnitOfMeasurementEntity> InitEntities()
    {
        return
        [
            new UnitOfMeasurementEntity
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Kilogram",
                ShortName = "Kg",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            },
            new UnitOfMeasurementEntity
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Gram",
                ShortName = "G",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            },
            new UnitOfMeasurementEntity
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Liter",
                ShortName = "L",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            },
            new UnitOfMeasurementEntity
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Deciliter",
                ShortName = "Dl",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            }
        ];
    }
}