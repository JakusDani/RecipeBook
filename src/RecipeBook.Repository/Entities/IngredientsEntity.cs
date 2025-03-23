namespace RecipeBook.Repository.Entities;

public class IngredientsEntity : BaseEntity
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public int UnitOfMeasurementId { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public RecipeEntity Recipe { get; set; } = null!;
    public UnitOfMeasurementEntity UnitOfMeasurement { get; set; } = null!;
}
