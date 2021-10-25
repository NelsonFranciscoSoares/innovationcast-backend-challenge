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
using System.Collections.Generic;

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

        private PagedResult<ComentarioEntity> ObterComentariosPorEntidadePaginadoAsync(Guid id, int pageSize, int pageIndex, IEnumerable<ComentarioEntity> comentarios, int totalComentarios)
        {
            return new PagedResult<ComentarioEntity>
            {
                Items = comentarios,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalResults = totalComentarios
            };
        }

        public async Task<PagedResult<ComentarioEntity>> ObterComentariosNovosPorEntidadePaginadoAsync(Guid id, Guid utilizadorId, int pageSize, int pageIndex)
        {
            var offset = this.CalculaOffset(pageSize, pageIndex);

            var comentarios = await this._discussaoDbContext.Comentarios
                                        .Where(param => param.EntidadeId == id && param.UtilizadoresVisualizaram.Select(innerParam => innerParam.Id).Contains(utilizadorId) == false)
                                        .AsNoTracking()
                                        .Skip(offset)
                                        .Take(pageSize)
                                        .OrderByDescending(p => p.DataPublicacao)
                                        .ToListAsync();

            var totalComentarios = await this._discussaoDbContext.Comentarios
                                                    .AsNoTracking()
                                                    .Where(param => param.EntidadeId == id && param.UtilizadoresVisualizaram.Select(innerParam => innerParam.Id).Contains(utilizadorId) == false)
                                                    .CountAsync();

            return  ObterComentariosPorEntidadePaginadoAsync(id, pageSize, pageIndex, comentarios, totalComentarios);
        }

        public async Task<PagedResult<ComentarioEntity>> ObterComentariosPorEntidadePaginadoAsync(Guid id, int pageSize, int pageIndex)
        {
            var offset = this.CalculaOffset(pageSize, pageIndex);

            var comentarios = await this._discussaoDbContext.Comentarios
                                                            .Where(param => param.EntidadeId == id)
                                                            .AsNoTracking()
                                                            .Skip(offset)
                                                            .Take(pageSize)
                                                            .OrderBy(p => p.DataPublicacao)
                                                            .ToListAsync();

            var totalComentarios = await this._discussaoDbContext.Comentarios
                                                            .Where(param => param.EntidadeId == id)
                                                            .AsNoTracking()
                                                            .CountAsync();

            return ObterComentariosPorEntidadePaginadoAsync(id, pageSize, pageIndex, comentarios, totalComentarios);
        }
    }
}
