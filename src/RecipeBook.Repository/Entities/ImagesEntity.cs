namespace RecipeBook.Repository.Entities;

public class ImagesEntity : BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string RecipeId { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;
    public RecipeEntity Recipe { get; set; } = null!;
}