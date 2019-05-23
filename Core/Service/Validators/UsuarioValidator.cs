using FluentValidation;
using Domain.Entities;
using System;

namespace Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
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

            RuleFor(c => c.Login)
                .NotEmpty()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Campo login obrigatorio.");
                });
        }
    }
}
