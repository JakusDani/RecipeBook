
using FluentValidation;

namespace RecipeBook.API.MiddleWares;

public class RecipeValidatorFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
        if (validator is not null)
        {
            var entity = context.Arguments
                .OfType<T>()
                .FirstOrDefault(a => a?.GetType() == typeof(T));
            if (entity is not null)
            {
                var results = await validator.ValidateAsync((entity));
                if (!results.IsValid)
                {
                    return Results.ValidationProblem(results.ToDictionary());
                }
            }
            else
            {
                return Results.Problem("Error Not Found");
            }
        }

        return await next(context);
    }
}