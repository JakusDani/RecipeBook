using Microsoft.EntityFrameworkCore;
using RecipeBook.Common.Enumeration;
using RecipeBook.Repository.Entities;
using RecipeBook.Repository.Extensions.Comparers;

namespace RecipeBook.Repository.Extensions;

public static class UnitOfMeasurementSeed
{
    public static DbContext AddUnitOfMeasurementIfNotExists(this DbContext context)
    {
        var unitOfMeasurements = context.Set<UnitOfMeasurementEntity>().ToList();
        var dataToSeed = InitEntities();

        if (unitOfMeasurements is null || unitOfMeasurements.Any() == false)
        {
            context.Set<UnitOfMeasurementEntity>()
                .AddRange(dataToSeed);
            return context;
        }

        UpdateDataIsChanged(dataToSeed, unitOfMeasurements);
        AddNewCategories(context, dataToSeed, unitOfMeasurements);
        return context;
    }

    private static void UpdateDataIsChanged(List<UnitOfMeasurementEntity> dataToSeed,
        List<UnitOfMeasurementEntity> unitOfMeasurements)
    {
        foreach (var item in unitOfMeasurements)
        {
            var currentItem = dataToSeed.FirstOrDefault(x => x.Name == item.Name);
            if (currentItem is not null
                && (item.Name != currentItem.Name
                    || item.ShortName != currentItem.ShortName
                    || item.MeasurementSystemId != currentItem.MeasurementSystemId))
            {
                item.Name = currentItem.Name;
                item.ShortName = currentItem.ShortName;
                item.MeasurementSystemId = currentItem.MeasurementSystemId;
                item.UpdatedAt = DateTime.Now;
            }
        }
    }

    private static void AddNewCategories(DbContext context,
        List<UnitOfMeasurementEntity> categoriesToSeed,
        List<UnitOfMeasurementEntity> categories)
    {
        var newValue = categoriesToSeed.Except(categories, new UnitOfMeasurementComparer()).ToList();
        context.Set<UnitOfMeasurementEntity>().AddRange(newValue);
    }

    private static List<UnitOfMeasurementEntity> InitEntities()
    {
        return
        [
            new UnitOfMeasurementEntity
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Kilogram",
                ShortName = "KG",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            },
            new UnitOfMeasurementEntity
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Gram",
                ShortName = "G",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            },
            new UnitOfMeasurementEntity
            {
                Id = 3,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Liter",
                ShortName = "L",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            },
            new UnitOfMeasurementEntity
            {
                Id = 4,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = "Deciliter",
                ShortName = "DL",
                MeasurementSystemId = (int)MeasurementSystems.Metric
            }
        ];
    }
}