using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using Backend.Challenge.Kernel.Domain;
using Backend.Challenge.Kernel.Domain.Miscellaneous;

namespace Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity, IAggregateRoot, new()
    {
        protected readonly DbSet<TEntity> DbSet;

        public abstract IUnitOfWork UnitOfWork { get; }

        protected BaseRepository(DbContext dbContext)
        {
            this.DbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AdicionarAsync(TEntity entity)
        {
            await this.DbSet.AddAsync(entity);
            return entity;
        }

        public Task<TEntity> ActualizarAsync(TEntity entity)
        {
            this.DbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.DbSet
                        .AsNoTracking()
                        .Where(predicate)
                        .ToListAsync();
        }

        public async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            return await this.DbSet
                            .FindAsync(id);
        }

        public async Task<PagedResult<TEntity>> ObterTodosPaginadoAsync(int pageSize, int pageIndex)
        {
            var offset = this.CalculaOffset(pageSize, pageIndex);

            var entities = await this.DbSet
                                .AsNoTracking()
                                .Skip(offset)
                                .Take(pageSize)
                                .ToListAsync();

            return new PagedResult<TEntity>
            {
                List = entities,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalResults = await ObtemNumeroTotalRegistosAsync()
            };
        }

        protected async Task<int> ObtemNumeroTotalRegistosAsync()
        {
            return await this.DbSet.CountAsync();
        }

        protected int CalculaOffset(int pageSize, int pageIndex)
        {
            return (pageIndex - 1) * pageSize;
        }

        public Task RemoverAsync(Guid id)
        {
            this.DbSet.Remove(new TEntity { Id = id });
            return Task.CompletedTask;
        }
    }
}
