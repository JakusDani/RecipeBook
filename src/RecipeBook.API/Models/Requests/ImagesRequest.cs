namespace RecipeBook.Common.Models.Requests;

public record ImagesRequest(
    string RecipeId,
    string Name,
    string ImageLink);
