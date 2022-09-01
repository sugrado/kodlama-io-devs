using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        private readonly IMapper _mapper;

        public UpdateProgrammingLanguageCommandHandler(
            IProgrammingLanguageRepository programmingLanguageRepository,
            ProgrammingLanguageBusinessRules programmingLanguageBusinessRules,
            IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            var programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
            _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenRequested(request.Name);

            _mapper.Map(request, programmingLanguage);
            var updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
            return _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
        }
    }
}
