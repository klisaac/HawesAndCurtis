﻿using HawesAndCurtis.Application.Queries;
using FluentValidation;

namespace HawesAndCurtis.Application.Validations
{
    public class SearchArgsValidator : AbstractValidator<PageSearchArgs>
    {
        public SearchArgsValidator()
        {
            RuleFor(request => request.Args).NotNull();
            RuleFor(request => request.Args.PageIndex).GreaterThan(0);
            RuleFor(request => request.Args.PageSize).InclusiveBetween(10, 100);
        }
    }
}
