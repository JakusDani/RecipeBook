namespace RecipeBook.Repository.Entities;

public class UnitOfMeasurementEntity : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public MeasurementSystemEntity MeasurementSystem { get; set; } = null!;
}
