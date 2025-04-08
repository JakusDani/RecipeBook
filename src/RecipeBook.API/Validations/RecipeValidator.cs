using FluentValidation;
using RecipeBook.Common.Models.Requests;

namespace RecipeBook.API.Validations;

public class RecipeValidator : AbstractValidator<RecipeRequest>
{
    public RecipeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Description are required.");
        RuleFor(x => x.MainImage)
            .NotEmpty()
            .WithMessage("MainImage are required.");
        RuleFor(x => x.Instruction)
            .NotEmpty()
            .MaximumLength(2000)
            .WithMessage("Instruction are required.");
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("CategoryId are required.");
        RuleFor(x => x.portionPerPerson)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("PortionPerPerson must be greater than 0.");
    }
}