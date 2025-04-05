using Microsoft.EntityFrameworkCore;
using RecipeBook.Common.Enumeration;
using RecipeBook.Repository.Entities;
using RecipeBook.Repository.Extensions.Comparers;

namespace RecipeBook.Repository.Extensions;

public static class CategorySeed
{
    public static DbContext AddCategoriesIfNotExists(this DbContext context)
    {
        var categoriesToSeed = Enum.GetValues<Categories>()
            .Select(item => new CategoryEntity
            {
                Id = (int)item,
                Name = item.ToString(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }).ToList();

        var categories = context.Set<CategoryEntity>()
            .ToList();

        // Init if db is empty
        if (categories is null || categories.Any() == false)
        {
            context.Set<CategoryEntity>().AddRange(categoriesToSeed);
            return context;
        }

        AddNewCategories(context, categoriesToSeed, categories);
        UpdateCategoryNames(categories);

        return context;
    }

    private static void UpdateCategoryNames(List<CategoryEntity> categories)
    {
        foreach (var item in categories)
        {
            var categoryName = ((Categories)item.Id).ToString();
            if (item.Name != categoryName)
            {
                item.Name = categoryName;
                item.UpdatedAt = DateTime.Now;
            }
        }
    }

    private static void AddNewCategories(DbContext context,
        List<CategoryEntity> categoriesToSeed,
        List<CategoryEntity> categories)
    {
        var newValue = categoriesToSeed.Except(categories, new CategoryComparer()).ToList();
        context.Set<CategoryEntity>().AddRange(newValue);
    }
}