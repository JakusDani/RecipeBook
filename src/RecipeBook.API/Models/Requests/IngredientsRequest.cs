namespace RecipeBook.Common.Models.Requests;

public record IngredientsRequest(
    string Name,
    int Quantity,
    int UnitOfMeasurementId,
    string RecipeId
);
