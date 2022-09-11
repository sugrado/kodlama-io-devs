using Application.Features.Authorizations.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Authorizations.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthorizationBusinessRules _authorizationBusinessRules;

        public LoginUserCommandHandler(IUserRepository userRepository, AuthorizationBusinessRules authorizationBusinessRules)
        {
            _userRepository = userRepository;
            _authorizationBusinessRules = authorizationBusinessRules;
        }

        public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userFound = await _userRepository.GetByMail(request.UserForLoginDto.Email);
            _authorizationBusinessRules.UserShouldExistWhenLogin(userFound);

            if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, userFound.PasswordHash, userFound.PasswordSalt))
                throw new BusinessException("Wrong password!");

            var accessToken = await _authorizationBusinessRules.CreateAccessToken(userFound);
            return accessToken;
        }
    }
}
