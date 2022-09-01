using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenRequested(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("The Programming Language name is already exists.");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language does not exist.");
        }
    }
}
