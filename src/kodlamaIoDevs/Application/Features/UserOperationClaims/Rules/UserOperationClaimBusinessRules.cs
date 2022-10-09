using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task UserOperationClaimCanNotBeDuplicatedWhenRequested(int userId, int operationClaimId)
        {
            IPaginate<UserOperationClaim> result = await _userOperationClaimRepository
                .GetListAsync(p => p.UserId == userId &&
                                   p.OperationClaimId == operationClaimId);

            if (result.Items.Any()) throw new BusinessException("The User Operation Claim is already exists.");
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("Requested User Operation Claim does not exist.");
        }
    }
}
