namespace RecipeBook.Repository.Entities;

public class RecipeEntity : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string MainImageLink { get; set; } = string.Empty;
    public string Instruction { get; set; } = string.Empty;
    public int PortionPerPerson { get; set; }
    public int CategoryId  { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public ICollection<IngredientsEntity> Ingredients { get; set; } = [];
    public ICollection<ImagesEntity> Images { get; set; } = [];
}
