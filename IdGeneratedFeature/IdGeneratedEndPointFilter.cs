using System;
using FluentValidation;

namespace idgenapi.IdGeneratedFeature;

public class IdGeneratedEndPointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.GetArgument<IValidator<IdCreateDto>>(0);
        var dto = context.GetArgument<IdCreateDto>(1);
        var validationResult = validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }
        return await next(context);
    }
}
