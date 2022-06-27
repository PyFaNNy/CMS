using CMS.Common;
using FluentValidation;

namespace CMS.Application.Aggregates.User.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.Password)
                .Must(PasswordsHelper.IsMeetsRequirements)
                .WithMessage("IncorrectPassword");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("IncorrectConfirmPassword");
        }
    }
}
