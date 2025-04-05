namespace RecipeBook.Repository.Entities;

public class UnitOfMeasurementEntity : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public int MeasurementSystemId { get; set; }
    public MeasurementSystemEntity MeasurementSystem { get; set; } = null!;
    public ICollection<IngredientsEntity> Ingredients { get; set; } = [];
}