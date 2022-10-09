using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenRequested(string name)
        {
            bool result = await _operationClaimRepository
                .Query()
                .Where(p => p.Name.ToLower() == name.ToLower())
                .AnyAsync();

            if (result) throw new BusinessException("The Operation Claim name is already exists.");
        }

        public void OperationClaimShouldExistWhenRequested(OperationClaim? operationClaim)
        {
            if (operationClaim == null) throw new BusinessException("Requested Operation Claim does not exist.");
        }

        public async Task OperationClaimShouldExistWhenRequested(int id)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(p => p.Id == id);
            if (operationClaim is null) throw new BusinessException("Requested Operation Claim does not exist.");
        }
    }
}
