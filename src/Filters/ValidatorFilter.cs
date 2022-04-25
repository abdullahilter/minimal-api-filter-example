using FluentValidation;

namespace MinimalApiFilterExample.Filters;

public class ValidatorFilter<T> : IRouteHandlerFilter
    where T : class
{
    private readonly IValidator<T> _validator;

    public ValidatorFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        var validatable = context.Parameters.FirstOrDefault(x => x.GetType() == typeof(T)) as T;

        if (validatable is null)
            return Results.BadRequest();

        var validationResult = await _validator.ValidateAsync(validatable);

        if (false == validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors.Select(s => s.ErrorMessage));

        return await next(context);
    }
}