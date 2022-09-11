using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommand : IRequest<CreatedUserSocialMediaDto>
    {
        public int UserId { get; set; }
        public SocialMediaTypes Type { get; set; }
        public string Link { get; set; }
    }

    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDto>
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        private readonly IMapper _mapper;
        private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

        public CreateSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper,
            UserSocialMediaBusinessRules userSocialMediaBusinessRules)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
            _mapper = mapper;
            _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
        }

        public async Task<CreatedUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _userSocialMediaBusinessRules.UserShouldExisWhenRequested(request.UserId);

            UserSocialMedia mappedUserSocialMedia = _mapper.Map<UserSocialMedia>(request);
            UserSocialMedia createdUserSocialMedia = await _userSocialMediaRepository.AddAsync(mappedUserSocialMedia);
            CreatedUserSocialMediaDto createdUserSocialMediaDto = _mapper.Map<CreatedUserSocialMediaDto>(createdUserSocialMedia);
            return createdUserSocialMediaDto;
        }
    }
}
