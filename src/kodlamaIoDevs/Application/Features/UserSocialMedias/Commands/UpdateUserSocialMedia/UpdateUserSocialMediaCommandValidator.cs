using FluentValidation;

namespace Application.Features.UserSocialMedias.Commands.UpdateUserSocialMedia
{
    public class UpdateUserSocialMediaCommandValidator : AbstractValidator<UpdateUserSocialMediaCommand>
    {
        public UpdateUserSocialMediaCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
        }
    }
}
