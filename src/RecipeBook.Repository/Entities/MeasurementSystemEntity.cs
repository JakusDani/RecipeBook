namespace RecipeBook.Repository.Entities;

public class MeasurementSystemEntity : BaseEntity
{
    public int Id { get; set; }
    public int UnitOfMeasurementId { get; set; }
    public string Name { get; set; } = string.Empty;
    public UnitOfMeasurementEntity UnitOfMeasurement { get; set; } = null!;
}