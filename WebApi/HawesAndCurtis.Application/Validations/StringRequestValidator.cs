﻿using FluentValidation;

namespace HawesAndCurtis.Application.Validations
{
    public class StringRequestValidator : AbstractValidator<string>
    {
        public StringRequestValidator()
        {
            RuleFor(x => x.ToString()).NotEmpty().WithMessage("Get parameter value cannout be null or empty.");
        }
    }
}
