using FluentValidation;

namespace Application.Features.Auths.Commands.LoginUser
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.UserForLoginDto)
                .NotNull();

            RuleFor(p => p.UserForLoginDto.Email)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Email cannot be empty.")
                .EmailAddress()
                    .WithMessage("The email format is invalid. Please enter a valid email address.");

            RuleFor(p => p.UserForLoginDto.Password)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Password cannot be empty.")
                .MinimumLength(8)
                    .WithMessage("Password length must be at least 8 characters long");
        }
    }
}
