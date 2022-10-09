using Application.Features.Users.Rules;
using Application.Features.UserSocialMedias.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommand : IRequest<CreatedUserSocialMediaDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public SocialMediaTypes Type { get; set; }
        public string Link { get; set; }
        public string[] Roles => new string[] { nameof(CreateUserSocialMediaCommand) };
    }

    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDto>
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper,
            UserBusinessRules userBusinessRules)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserShouldExistWhenRequested(request.UserId);

            UserSocialMedia mappedUserSocialMedia = _mapper.Map<UserSocialMedia>(request);
            UserSocialMedia createdUserSocialMedia = await _userSocialMediaRepository.AddAsync(mappedUserSocialMedia);
            CreatedUserSocialMediaDto createdUserSocialMediaDto = _mapper.Map<CreatedUserSocialMediaDto>(createdUserSocialMedia);
            return createdUserSocialMediaDto;
        }
    }
}
