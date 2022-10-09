using FluentValidation;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
            RuleFor(p => p.Name).NotEmpty().NotNull();
        }
    }
}
