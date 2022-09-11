using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguageTechnologies.Rules
{
    public class ProgrammingLanguageTechnologyBusinessRules
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageTechnologyBusinessRules(
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository,
            IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }
        public async Task ProgrammingLanguageTechnologyNameCanNotBeDuplicatedWhenRequested(int programmingLanguageId, string name)
        {
            IPaginate<ProgrammingLanguageTechnology> result = await _programmingLanguageTechnologyRepository
                .GetListAsync(p => p.Name.ToLower() == name.ToLower() && p.ProgrammingLanguageId == programmingLanguageId);
            if (result.Items.Any()) throw new BusinessException("The Programming Language Technology name is already exists.");
        }

        public async Task ProgrammingLanguageShouldExistWhenRequested(int programmingLanguageId)
        {
            var result = await _programmingLanguageRepository.GetAsync(p => p.Id == programmingLanguageId);
            if (result is null) throw new BusinessException("Requested Programming Language does not exist");
        }

        public void ProgrammingLanguageTechnologyShouldExistWhenRequested(ProgrammingLanguageTechnology? programmingLanguageTechnology)
        {
            if (programmingLanguageTechnology is null) throw new BusinessException("Requested Programming Language Technology does not exist");
        }
    }
}
