using Domain.Enums;

namespace Application.Features.UserSocialMedias.Dtos
{
    public class DeletedUserSocialMediaDto
    {
        public SocialMediaTypes Type { get; set; }
        public string Link { get; set; }
    }
}
