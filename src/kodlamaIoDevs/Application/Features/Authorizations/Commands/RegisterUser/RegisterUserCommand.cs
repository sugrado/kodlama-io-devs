using Application.Features.Authorizations.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Authorizations.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthorizationBusinessRules _authorizationBusinessRules;

        public RegisterUserCommandHandler(IUserRepository userRepository, AuthorizationBusinessRules authorizationBusinessRules)
        {
            _userRepository = userRepository;
            _authorizationBusinessRules = authorizationBusinessRules;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _authorizationBusinessRules.EmailMustNotExistWhenRegistered(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var registeredUser = new User
            {
                Email = request.UserForRegisterDto.Email,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AuthenticatorType = AuthenticatorType.None, // TODO: Email or Otp Authenticator will be used
                Status = true,
            };

            await _userRepository.AddAsync(registeredUser);
            return Unit.Value;
        }
    }
}
