using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
    {
        public int Id { get; set; }
    }

    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(
            IOperationClaimRepository operationClaimRepository,
            OperationClaimBusinessRules operationClaimBusinessRules,
            IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(p => p.Id == request.Id);
            _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);

            var deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);
            return _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
        }
    }
}
