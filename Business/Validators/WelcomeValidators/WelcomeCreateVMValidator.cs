using Core.Models;
using FluentValidation;

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
