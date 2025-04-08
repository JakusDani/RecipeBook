using RecipeBook.Common.Enumeration;

namespace RecipeBook.Common.Models.Requests;

public record RecipeRequest(
    string Name,
    string Description,
    string MainImage,
    string Instruction,
    Categories CategoryId,
    int portionPerPerson
);