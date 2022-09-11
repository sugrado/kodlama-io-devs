using Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedias.Commands.UpdateUserSocialMedia;
using Application.Features.UserSocialMedias.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserSocialMedias.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSocialMedia, CreatedUserSocialMediaDto>().ReverseMap();
            CreateMap<UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, UpdateUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, UpdatedUserSocialMediaDto>().ReverseMap();
            CreateMap<UserSocialMedia, DeletedUserSocialMediaDto>().ReverseMap();
        }
    }
}
