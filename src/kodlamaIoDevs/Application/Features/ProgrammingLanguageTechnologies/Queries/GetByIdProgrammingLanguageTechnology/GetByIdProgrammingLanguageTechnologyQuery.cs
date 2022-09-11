using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyGetByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyGetByIdDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;
        public GetByIdProgrammingLanguageTechnologyQueryHandler(
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository,
            IMapper mapper,
            ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<ProgrammingLanguageTechnologyGetByIdDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(p => p.Id == request.Id);
            _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyShouldExistWhenRequested(programmingLanguageTechnology);
            return _mapper.Map<ProgrammingLanguageTechnologyGetByIdDto>(programmingLanguageTechnology);
        }
    }
}
