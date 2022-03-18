using Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.DoctorValidators
{
  public  class DoctorCreateVMValidator : AbstractValidator<Doctor>
    {
        public DoctorCreateVMValidator()
        {
            RuleFor(d => d.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(d => d.Surname)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(d => d.Phone)
                .NotNull()
                .NotEmpty();
            RuleFor(d => d.Address)
                .NotNull()
                .NotEmpty();
            RuleFor(d => d.EmailAddress)
                .NotNull()
                .NotEmpty();
            RuleFor(d => d.Education)
               .NotNull()
               .NotEmpty();
            RuleFor(d => d.Fees)
               .NotNull()
               .NotEmpty();
            RuleFor(d => d.Splztion)
               .NotNull()
               .NotEmpty();
            RuleFor(d => d.Splztion)
               .NotNull()
               .NotEmpty();
            RuleFor(d => d.Gender)
               .NotNull()
               .NotEmpty();
            RuleFor(d => d.Photo)
               .NotNull()
               .NotEmpty();
            RuleFor(d => d.WorkingHours)
               .NotNull()
               .NotEmpty();
            RuleFor(d => d.IsDeleted)
               .NotNull()
               .NotEmpty();

        }
    }
}
