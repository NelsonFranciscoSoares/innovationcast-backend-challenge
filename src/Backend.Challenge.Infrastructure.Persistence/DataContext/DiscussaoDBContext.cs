using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Domain.Entities;
using Backend.Challenge.Kernel.Domain.Miscellaneous;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.Infrastructure.Persistence.DataContext
{
    public class DiscussaoDBContext : DbContext, IUnitOfWork
    {
        public DbSet<EntidadeEntity> Entidades { get; set; }
        public DbSet<ComentarioEntity> Comentarios { get; set; }
        public DbSet<UtilizadorEntity> Utilizadores { get; set; }

        public DiscussaoDBContext(DbContextOptions<DiscussaoDBContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscussaoDBContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
               .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker
                .Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DataInsercao = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.DataEdicao = DateTime.UtcNow;
                        break;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }
    }
}
