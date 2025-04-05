using RecipeBook.Repository.Entities;
using System.Diagnostics.CodeAnalysis;

namespace RecipeBook.Repository.Extensions.Comparers;

internal class MeasurementSystemComparer : IEqualityComparer<MeasurementSystemEntity>
{
    public bool Equals(MeasurementSystemEntity? x, MeasurementSystemEntity? y)
    {
        return x?.Id == y?.Id;
    }

    public int GetHashCode([DisallowNull] MeasurementSystemEntity obj)
    {
        return obj.Id.GetHashCode();
    }
}