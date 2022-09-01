using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
            RuleFor(p => p.Name).NotEmpty().NotNull();
        }
    }
}
