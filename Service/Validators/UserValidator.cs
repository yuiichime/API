using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Usuário não encontrado");
                    });

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage(" O campo Login é obrigatório.")
                .NotNull().WithMessage(" O campo Login é obrigatório.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(" O campo Email é obrigatório.")
                .NotNull().WithMessage(" O campo Email é obrigatório.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(" O campo Nome é obrigatório.")
                .NotNull().WithMessage(" O campo Nome é obrigatório.");
        }
    }

}
