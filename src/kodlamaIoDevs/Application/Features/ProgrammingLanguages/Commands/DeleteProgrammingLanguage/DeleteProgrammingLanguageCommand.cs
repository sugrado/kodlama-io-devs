using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }
    }

    public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        private readonly IMapper _mapper;

        public DeleteProgrammingLanguageCommandHandler(
            IProgrammingLanguageRepository programmingLanguageRepository,
            ProgrammingLanguageBusinessRules programmingLanguageBusinessRules,
            IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            var programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
            _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

            var deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
            return _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
        }
    }
}
