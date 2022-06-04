using BlazorSozluk.Common.Models.RequestModels;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Commands.User.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(i => i.Email).NotNull().EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("{PropertyName} not a valida Email");

            RuleFor(i => i.Password).NotNull().MinimumLength(6).WithMessage("{PropertyName} should a least be {MinLenght} characters");
        }
    }
}
