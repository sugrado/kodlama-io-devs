using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnologyTechnology;
using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommandValidator : AbstractValidator<DeleteProgrammingLanguageTechnologyCommand>
    {
        public DeleteProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
