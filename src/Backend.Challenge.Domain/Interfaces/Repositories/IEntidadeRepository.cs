using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Domain;
using Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.Domain.Interfaces.Repositories
{
    public interface IEntidadeRepository : IRepository<EntidadeEntity>
    {
        Task<PagedResult<ComentarioEntity>> ObterComentariosPorEntidadePaginadoAsync(Guid id, int pageSize, int pageIndex);
        Task<PagedResult<ComentarioEntity>> ObterComentariosNovosPorEntidadePaginadoAsync(Guid id, Guid utilizadorId, int pageSize, int pageIndex);
    }
}
