using Backend.Challenge.Kernel.Domain;
using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using Backend.Challenge.Kernel.Domain.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity, IAggregateRoot
    {
        Task<TEntity> AdicionarAsync(TEntity entity);
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<PagedResult<TEntity>> ObterTodosPaginadoAsync(int pageSize, int pageIndex);
        Task<TEntity> AtualizarAsync(TEntity entity);
        Task RemoverAsync(Guid id);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
        IUnitOfWork UnitOfWork { get; }
    }
}
