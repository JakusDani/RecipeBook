namespace RecipeBook.Repository.Entities;

public class MeasurementSystemEntity : BaseEntity
{
    public int Id { get; set; }
    public int UnitOfMeasurementId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<UnitOfMeasurementEntity> UnitOfMeasurements { get; set; } = null!;
}