using FluentValidation;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("The Operation Claim name is required.")
                .MinimumLength(3)
                    .WithMessage("Operation claim name must be at least 3 characters long.");
        }
    }
}
