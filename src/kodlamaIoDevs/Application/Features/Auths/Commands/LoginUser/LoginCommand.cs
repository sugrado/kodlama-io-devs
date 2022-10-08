using Application.Features.Auths.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.LoginUser
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly UserBusinessRules _userBusinessRules;

        public LoginUserCommandHandler(IUserRepository userRepository, 
            IAuthService authService, 
            UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _authService = authService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var foundUser = await _userRepository.GetByMail(request.UserForLoginDto.Email);
            _userBusinessRules.UserShouldExistWhenRequested(foundUser);

            if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, foundUser.PasswordHash, foundUser.PasswordSalt))
                throw new BusinessException("Wrong password!");

            var accessToken = await _authService.CreateAccessToken(foundUser);
            return accessToken;
        }
    }
}
