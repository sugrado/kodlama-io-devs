using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProgrammingLanguageTechnologyRepository : EfRepositoryBase<ProgrammingLanguageTechnology, BaseDbContext>, IProgrammingLanguageTechnologyRepository
    {
        public ProgrammingLanguageTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
