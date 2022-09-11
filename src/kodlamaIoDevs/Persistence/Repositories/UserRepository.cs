using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByMail(string email)
            => await GetAsync(p => p.Email == email);

        public async Task<IList<OperationClaim>> GetClaims(int userId)
            => await Query()
                .AsNoTracking()
                .Where(p => p.Id == userId)
                .SelectMany(p => p.UserOperationClaims)
                .Select(p => new OperationClaim
                {
                    Id = p.OperationClaimId,
                    Name = p.OperationClaim.Name
                })
                .ToListAsync();
    }
}
