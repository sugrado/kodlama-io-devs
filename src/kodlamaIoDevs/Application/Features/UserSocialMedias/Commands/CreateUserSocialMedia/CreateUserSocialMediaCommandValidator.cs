using FluentValidation;

namespace Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommandValidator : AbstractValidator<CreateUserSocialMediaCommand>
    {
        public CreateUserSocialMediaCommandValidator()
        {
            RuleFor(p => p.Link).NotEmpty().NotEmpty();
            RuleFor(p => p.Type).NotEmpty().NotEmpty();
        }
    }
}
