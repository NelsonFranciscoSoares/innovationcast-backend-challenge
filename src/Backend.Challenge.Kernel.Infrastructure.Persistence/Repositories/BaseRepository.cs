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
        private readonly DbContext DbContext;

        protected BaseRepository(DbContext dbContext)
        {
            this.DbContext = dbContext;
            this.DbSet = dbContext.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            await this.DbSet.AddAsync(entity);
        }

        public Task Atualizar(TEntity entity)
        {
            this.DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.DbSet
                        .AsNoTracking()
                        .Where(predicate)
                        .ToListAsync();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await this.DbSet
                            .FindAsync(id);
        }

        public async Task<PagedResult<TEntity>> ObterTodos(int pageSize, int pageIndex)
        {
            var offset = this.CalculaOffset(pageSize, pageIndex);

            var entities = await this.DbSet.Skip(offset)
                                .Take(pageSize)
                                .ToListAsync();

            return new PagedResult<TEntity>
            {
                List = entities,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalResults = await ObtemNumeroTotalRegistos()
            };
        }

        protected async Task<int> ObtemNumeroTotalRegistos()
        {
            return await this.DbSet.CountAsync();
        }

        protected int CalculaOffset(int pageSize, int pageIndex)
        {
            return (pageIndex - 1) * pageSize;
        }

        public Task Remover(Guid id)
        {
            this.DbSet.Remove(new TEntity { Id = id });
            return Task.CompletedTask;
        }
    }
}
