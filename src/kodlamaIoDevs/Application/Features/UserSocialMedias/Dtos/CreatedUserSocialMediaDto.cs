using Domain.Enums;

namespace Application.Features.UserSocialMedias.Dtos
{
    public class CreatedUserSocialMediaDto
    {
        public SocialMediaTypes Type { get; set; }
        public string Link { get; set; }
    }
}
