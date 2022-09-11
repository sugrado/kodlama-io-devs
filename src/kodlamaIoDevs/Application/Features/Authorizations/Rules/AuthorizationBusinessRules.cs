using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Authorizations.Rules
{
    public class AuthorizationBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public AuthorizationBusinessRules(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task EmailMustNotExistWhenRegistered(string email)
        {
            var userExist = await _userRepository
                .Query()
                .AsNoTracking()
                .Where(p => p.Email == email)
                .AnyAsync();

            if (userExist)
                throw new BusinessException("Your email address in already registered.");
        }

        public void UserShouldExistWhenLogin(User? userFound)
        {
            if (userFound is null)
                throw new BusinessException("No account found for this email address. Please register or make sure you entered email address correctly.");
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var claims = await _userRepository.GetClaims(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}
