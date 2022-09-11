using Domain.Enums;

namespace Application.Features.UserSocialMedias.Dtos
{
    public class UpdatedUserSocialMediaDto
    {
        public SocialMediaTypes Type { get; set; }
        public string Link { get; set; }
    }
}
