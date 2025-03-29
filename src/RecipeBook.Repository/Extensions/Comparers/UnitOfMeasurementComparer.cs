using RecipeBook.Repository.Entities;
using System.Diagnostics.CodeAnalysis;

namespace RecipeBook.Repository.Extensions.Comparers;

internal class UnitOfMeasurementComparer : IEqualityComparer<UnitOfMeasurementEntity>
{
    public bool Equals(UnitOfMeasurementEntity? x, UnitOfMeasurementEntity? y)
    {
        return x?.Id == y?.Id;
    }

    public int GetHashCode([DisallowNull] UnitOfMeasurementEntity obj)
    {
        return obj.Id.GetHashCode();
    }
}