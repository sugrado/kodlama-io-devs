using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.UserSocialMedias.Rules
{
    public class UserSocialMediaBusinessRules
    {
        public void UserSocialMediaShouldExistWhenRequested(UserSocialMedia? userSocialMedia)
        {
            if (userSocialMedia == null) throw new BusinessException("Requested user social media does not exist.");
        }
    }
}
