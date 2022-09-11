using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class UserSocialMedia : Entity
    {
        public int UserId { get; set; }
        public SocialMediaTypes Type { get; set; }
        public string Link { get; set; }
        public User User { get; set; }

        public UserSocialMedia(int id, int userId, SocialMediaTypes type, string link) : this()
        {
            Id = id;
            UserId = userId;
            Type = type;
            Link = link;
        }

        public UserSocialMedia()
        {

        }
    }
}
