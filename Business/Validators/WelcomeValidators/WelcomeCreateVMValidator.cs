using Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.WelcomeValidators
{
    class WelcomeCreateVMValidator : AbstractValidator<Welcome>
    {
        public WelcomeCreateVMValidator()
        {
            RuleFor(d => d.Title)
               .NotNull()
               .NotEmpty()
               .MaximumLength(255);
            RuleFor(d => d.Content)
               .NotNull()
               .NotEmpty()
               .MaximumLength(255);
            RuleFor(d => d.WhyUs)
               .NotNull()
               .NotEmpty()
               .MaximumLength(255);
            RuleFor(d => d.WhyUs)
              .NotNull()
              .NotEmpty();
        }
    }
}
