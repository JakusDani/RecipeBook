namespace RecipeBook.Repository.Entities;

public class ImagesEntity : BaseEntity
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;
    public RecipeEntity Recipe { get; set; } = null!;
}