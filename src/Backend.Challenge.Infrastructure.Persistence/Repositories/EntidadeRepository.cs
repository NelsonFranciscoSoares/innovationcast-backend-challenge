using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Interfaces.Repositories;
using Backend.Challenge.Infrastructure.Persistence.DataContext;
using Backend.Challenge.Kernel.Domain.Miscellaneous;
using Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using System.Linq;
using Backend.Challenge.Kernel.Domain;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PagedResult<ComentarioEntity>> ObterComentariosPorEntidadePaginadoAsync(Guid id, int pageSize, int pageIndex)
        {
            var offset = this.CalculaOffset(pageSize, pageIndex);

            var comentarios = await this._discussaoDbContext.Comentarios
                                        .Where(param => param.EntidadeId == id)
                                        .AsNoTracking()
                                        .Skip(offset)
                                        .Take(pageSize)
                                        .OrderByDescending(param => param.DataPublicacao)
                                        .ToListAsync();

            return new PagedResult<ComentarioEntity>
            {
                Items = comentarios,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalResults = await this._discussaoDbContext.Comentarios.CountAsync()
            };
        }
    }
}
