using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommand>
    {
        public CreateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(64);
            RuleFor(p => p.Description).MaximumLength(512);
            RuleFor(p => p.ProgrammingLanguageId).NotEmpty().NotNull();
        }
    }
}
