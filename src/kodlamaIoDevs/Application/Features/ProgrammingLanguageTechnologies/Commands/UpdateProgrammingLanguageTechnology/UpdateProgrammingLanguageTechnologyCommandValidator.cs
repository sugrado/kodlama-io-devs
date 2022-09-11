using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
            RuleFor(p => p.ProgrammingLanguageId).NotEmpty().NotNull();
            RuleFor(p => p.Name).NotEmpty().NotNull();
            RuleFor(p => p.Description).MaximumLength(512);
        }
    }
}
