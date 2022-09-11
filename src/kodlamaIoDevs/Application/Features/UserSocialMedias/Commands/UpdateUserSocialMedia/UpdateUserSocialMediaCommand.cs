using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Enums;
using MediatR;

namespace Application.Features.UserSocialMedias.Commands.UpdateUserSocialMedia
{
    public class UpdateUserSocialMediaCommand : IRequest<UpdatedUserSocialMediaDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public SocialMediaTypes Type { get; set; }
        public string Link { get; set; }
    }

    public class UpdateUserSocialMediaCommandHandler : IRequestHandler<UpdateUserSocialMediaCommand, UpdatedUserSocialMediaDto>
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;
        private readonly IMapper _mapper;

        public UpdateUserSocialMediaCommandHandler(
            IUserSocialMediaRepository userSocialMediaRepository,
            UserSocialMediaBusinessRules userSocialMediaBusinessRules,
            IMapper mapper)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
            _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedUserSocialMediaDto> Handle(UpdateUserSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _userSocialMediaBusinessRules.UserShouldExisWhenRequested(request.UserId);

            var userSocialMedia = await _userSocialMediaRepository.GetAsync(p => p.Id == request.Id);
            _userSocialMediaBusinessRules.UserSocialMediaShouldExistWhenRequested(userSocialMedia);

            _mapper.Map(request, userSocialMedia);
            var updatedUserSocialMedia = await _userSocialMediaRepository.UpdateAsync(userSocialMedia);
            return _mapper.Map<UpdatedUserSocialMediaDto>(updatedUserSocialMedia);
        }
    }
}
