using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Interfaces.Repositories;
using Backend.Challenge.Infrastructure.Persistence.DataContext;
using Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories;

namespace Backend.Challenge.Infrastructure.Persistence.Repositories
{
    public class EntidadeRepository : BaseRepository<EntidadeEntity>, IEntidadeRepository
    {
        public EntidadeRepository(DiscussaoDBContext dbContext)
            :base(dbContext)
        {
        }
    }
}
