using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Interfaces.Repositories;
using Backend.Challenge.Infrastructure.Persistence.DataContext;
using Backend.Challenge.Kernel.Domain.Miscellaneous;
using Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.Challenge.Infrastructure.Persistence.Repositories
{
    public class EntidadeRepository : BaseRepository<EntidadeEntity>, IEntidadeRepository
    {
        private DiscussaoDBContext _discussaoDbContext;

        public EntidadeRepository(DiscussaoDBContext dbContext)
            :base(dbContext)
        {
            this._discussaoDbContext = dbContext;
        }

        public override IUnitOfWork UnitOfWork => this._discussaoDbContext;
    }
}
