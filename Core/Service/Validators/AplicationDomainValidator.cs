using FluentValidation;
using Domain.Entities;
using System;

namespace Service.Validators
{
    public class AplicationDomainValidator : AbstractValidator<AplicationDomain>
    {
        public AplicationDomainValidator()
        {
            Validation();
        }

        private void Validation()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Object is null.");
                });
          
        }
    }
}
