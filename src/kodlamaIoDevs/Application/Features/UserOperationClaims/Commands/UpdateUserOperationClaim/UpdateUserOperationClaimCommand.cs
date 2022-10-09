using Application.Features.OperationClaims.Rules;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }

    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimCommandHandler(
            IUserOperationClaimRepository userOperationClaimRepository,
            UserOperationClaimBusinessRules userOperationClaimBusinessRules,
            IMapper mapper,
            UserBusinessRules userBusinessRules,
            OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(request.OperationClaimId);
            await _userBusinessRules.UserShouldExistWhenRequested(request.UserId);
            await _userOperationClaimBusinessRules.UserOperationClaimCanNotBeDuplicatedWhenRequested(request.UserId, request.OperationClaimId);

            var userOperationClaim = await _userOperationClaimRepository.GetAsync(p => p.Id == request.Id);
            _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequested(userOperationClaim);

            _mapper.Map(request, userOperationClaim);
            var updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
            return _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
        }
    }
}
