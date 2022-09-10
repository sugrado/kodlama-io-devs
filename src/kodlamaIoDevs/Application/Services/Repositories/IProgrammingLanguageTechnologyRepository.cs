using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IProgrammingLanguageTechnologyRepository : IAsyncRepository<ProgrammingLanguageTechnology>, IRepository<ProgrammingLanguageTechnology>
    {
    }
}
