using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserSocialMediaRepository : EfRepositoryBase<UserSocialMedia, BaseDbContext>, IUserSocialMediaRepository
    {
        public UserSocialMediaRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
