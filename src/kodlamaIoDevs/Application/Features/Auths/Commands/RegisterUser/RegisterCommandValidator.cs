using FluentValidation;

namespace Application.Features.Auths.Commands.RegisterUser
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.UserForRegisterDto)
                .NotNull();

            RuleFor(p => p.UserForRegisterDto.Email)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Email cannot be empty.")
                .EmailAddress()
                    .WithMessage("The email format is invalid. Please enter a valid email address.");

            RuleFor(p => p.UserForRegisterDto.FirstName)
                .NotNull()
                .NotEmpty()
                    .WithMessage("First name cannot be empty.")
                .MinimumLength(2)
                    .WithMessage("First name length must be at least 2 characters long."); ;

            RuleFor(p => p.UserForRegisterDto.LastName)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Last name cannot be empty.")
                .MinimumLength(2)
                    .WithMessage("Last name length must be at least 2 characters long");

            RuleFor(p => p.UserForRegisterDto.Password)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Password cannot be empty.")
                .MinimumLength(8)
                    .WithMessage("Password length must be at least 8 characters long");
        }
    }
}
