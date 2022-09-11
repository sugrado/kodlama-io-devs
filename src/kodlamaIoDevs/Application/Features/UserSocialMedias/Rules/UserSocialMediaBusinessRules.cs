using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.UserSocialMedias.Rules
{
    public class UserSocialMediaBusinessRules
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        private readonly IUserRepository _userRepository;

        public UserSocialMediaBusinessRules(IUserSocialMediaRepository userSocialMediaRepository, IUserRepository userRepository)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
            _userRepository = userRepository;
        }

        public void UserSocialMediaShouldExistWhenRequested(UserSocialMedia? userSocialMedia)
        {
            if (userSocialMedia == null) throw new BusinessException("Requested user social media does not exist.");
        }

        public async Task UserShouldExisWhenRequested(int userId)
        {
            var userFound = await _userRepository.GetAsync(p => p.Id == userId);
            if (userFound is null)
                throw new BusinessException("User not found.");
        }
    }
}
