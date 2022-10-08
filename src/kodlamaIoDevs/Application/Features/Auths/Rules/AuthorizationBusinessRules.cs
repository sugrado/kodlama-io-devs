using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public AuthBusinessRules(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            var userExist = await _userRepository
                .Query()
                .AsNoTracking()
                .Where(p => p.Email == email)
                .AnyAsync();

            if (userExist)
                throw new BusinessException("Your email address in already registered.");
        }
    }
}
