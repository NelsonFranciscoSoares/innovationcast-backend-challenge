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
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<PagedResult<TEntity>> ObterTodos(int pageSize, int pageIndex);
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}
