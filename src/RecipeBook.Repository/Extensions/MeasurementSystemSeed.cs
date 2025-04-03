using Microsoft.EntityFrameworkCore;
using RecipeBook.Common.Enumeration;
using RecipeBook.Repository.Entities;
using RecipeBook.Repository.Extensions.Comparers;

namespace RecipeBook.Repository.Extensions;

public static class MeasurementSystemSeed
{
    public static DbContext AddMeasurementSystemIfNotExists(this DbContext context)
    {
        var categoriesToSeed = Enum.GetValues<MeasurementSystems>()
            .Select(item => new MeasurementSystemEntity
            {
                Id = (int)item,
                Name = item.ToString(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }).ToList();

        var categories = context.Set<MeasurementSystemEntity>()
            .ToList();

        // Init if db is empty
        if (categories is null || categories.Any() == false)
        {
            context.Set<MeasurementSystemEntity>().AddRange(categoriesToSeed);
            return context;
        }

        AddNewCategories(context, categoriesToSeed, categories);
        UpdateMeasurementSystemNames(categories);

        return context;
    }

    private static void AddNewCategories(DbContext context,
        List<MeasurementSystemEntity> categoriesToSeed,
        List<MeasurementSystemEntity> categories)
    {
        var newValue = categoriesToSeed.Except(categories, new MeasurementSystemComparer()).ToList();
        context.Set<MeasurementSystemEntity>().AddRange(newValue);
    }

    private static void UpdateMeasurementSystemNames(List<MeasurementSystemEntity> categories)
    {
        foreach (var item in categories)
        {
            var categoryName = ((MeasurementSystems)item.Id).ToString();
            if (item.Name != categoryName)
            {
                item.Name = categoryName;
                item.UpdatedAt = DateTime.Now;
            }
        }
    }
}