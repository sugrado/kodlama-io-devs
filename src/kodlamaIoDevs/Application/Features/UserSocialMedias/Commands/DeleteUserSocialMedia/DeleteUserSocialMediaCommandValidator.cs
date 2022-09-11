using FluentValidation;

namespace Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia
{
    public class DeleteUserSocialMediaCommandValidator : AbstractValidator<DeleteUserSocialMediaCommand>
    {
        public DeleteUserSocialMediaCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty();
        }
    }
}
