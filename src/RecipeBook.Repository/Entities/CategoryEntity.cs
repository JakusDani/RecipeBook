namespace RecipeBook.Repository.Entities;

public class CategoryEntity : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<RecipeEntity> Recipes { get; set; } = [];
}