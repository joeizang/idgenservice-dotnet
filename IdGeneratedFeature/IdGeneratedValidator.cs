using System;
using FluentValidation;

namespace idgenapi.IdGeneratedFeature;

public class IdGeneratedValidator : AbstractValidator<IdCreateDto>
{
    public IdGeneratedValidator()
    {
        RuleFor(x => x.ServerName).MinimumLength(5);
        RuleFor(x => x.ServerIp)
            .Matches(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")
            .MinimumLength(5);
    }
}
