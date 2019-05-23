using FluentValidation;
using Domain.Entities;
using System;

namespace Service.Validators
{
    public class AplicationDomainValidator : AbstractValidator<AplicationDomain>
    {
        public AplicationDomainValidator()
        {
            ValidaDados();
        }

        private void ValidaDados()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Objeto nao carregado.");
                });
          
        }
    }
}
