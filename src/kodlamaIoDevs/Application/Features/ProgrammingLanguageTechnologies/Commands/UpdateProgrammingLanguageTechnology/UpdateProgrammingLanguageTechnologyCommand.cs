using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdatedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;
        private readonly IMapper _mapper;

        public UpdateProgrammingLanguageTechnologyCommandHandler(
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository,
            ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules,
            IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            var programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(p => p.Id == request.Id);
            _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyShouldExistWhenRequested(programmingLanguageTechnology);
            await _programmingLanguageTechnologyBusinessRules
                .ProgrammingLanguageTechnologyNameCanNotBeDuplicatedWhenRequested(request.ProgrammingLanguageId, request.Name);

            _mapper.Map(request, programmingLanguageTechnology);
            var updatedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnology);
            return _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(updatedProgrammingLanguageTechnology);
        }
    }
}
