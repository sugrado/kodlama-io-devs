﻿using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IUserSocialMediaRepository : IAsyncRepository<UserSocialMedia>, IRepository<UserSocialMedia>
    {
    }
}
