namespace RecipeBook.Repository.old.Entities;

public class RecipesEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Preparation { get; set; } = string.Empty;
    public int CategoriesId { get; set; }
    public int PortionPerPerson { get; set; }
    public string MainImageLink { get; set; } = string.Empty;
    public CategoriesEntity Category { get; set; } = new();
}