namespace RecipeBook.Repository.Entities;

public class IngredientsEntity : BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string RecipeId { get; set; } = null!;
    public int UnitOfMeasurementId { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public RecipeEntity Recipe { get; set; } = null!;
    public UnitOfMeasurementEntity UnitOfMeasurement { get; set; } = null!;
}
