using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var userFound = await _userRepository.GetAsync(p => p.Id == userId);
            if (userFound is null)
                throw new BusinessException("User not found.");
        }

        public void UserShouldExistWhenRequested(User? userFound)
        {
            if (userFound is null)
                throw new BusinessException("User not found.");
        }
    }
}
