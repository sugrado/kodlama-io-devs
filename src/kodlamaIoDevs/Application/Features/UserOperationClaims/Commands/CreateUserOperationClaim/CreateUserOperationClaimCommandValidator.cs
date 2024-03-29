﻿using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.OperationClaimId)
                .NotNull()
                .NotEmpty();
        }
    }
}
