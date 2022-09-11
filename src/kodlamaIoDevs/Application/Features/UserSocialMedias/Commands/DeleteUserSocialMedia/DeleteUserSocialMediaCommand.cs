using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia
{
    public class DeleteUserSocialMediaCommand : IRequest<DeletedUserSocialMediaDto>
    {
        public int Id { get; set; }
    }

    public class DeleteUserSocialMediaCommandHandler : IRequestHandler<DeleteUserSocialMediaCommand, DeletedUserSocialMediaDto>
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;
        private readonly IMapper _mapper;

        public DeleteUserSocialMediaCommandHandler(
            IUserSocialMediaRepository userSocialMediaRepository,
            UserSocialMediaBusinessRules userSocialMediaBusinessRules,
            IMapper mapper)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
            _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedUserSocialMediaDto> Handle(DeleteUserSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var userSocialMedia = await _userSocialMediaRepository.GetAsync(p => p.Id == request.Id);
            _userSocialMediaBusinessRules.UserSocialMediaShouldExistWhenRequested(userSocialMedia);

            var deletedUserSocialMedia = await _userSocialMediaRepository.DeleteAsync(userSocialMedia);
            return _mapper.Map<DeletedUserSocialMediaDto>(deletedUserSocialMedia);
        }
    }
}
