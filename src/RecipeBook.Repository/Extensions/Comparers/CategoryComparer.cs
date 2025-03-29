using RecipeBook.Repository.Entities;
using System.Diagnostics.CodeAnalysis;

namespace RecipeBook.Repository.Extensions.Comparers;

internal class CategoryComparer : IEqualityComparer<CategoryEntity>
{
    public bool Equals(CategoryEntity? x, CategoryEntity? y)
    {
        return x?.Id == y?.Id;
    }

    public int GetHashCode([DisallowNull] CategoryEntity obj)
    {
        return obj.Id.GetHashCode();
    }
}
