using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Infrastructure.Persistence.DataContext
{
    public static class InitialDataScript
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var entidadeFactory = new EntidadeFactory();

            var teste01user = new UtilizadorEntity("Teste01", "teste01@gmail.com");
            var teste02user = new UtilizadorEntity("Teste02", "teste02@gmail.com");

            modelBuilder.Entity<UtilizadorEntity>().HasData(teste01user);
            modelBuilder.Entity<UtilizadorEntity>().HasData(teste02user);

            modelBuilder.Entity<EntidadeEntity>().HasData(entidadeFactory.Create(TipoEntidadeEnum.IDEIA, teste01user.Id));
            modelBuilder.Entity<EntidadeEntity>().HasData(entidadeFactory.Create(TipoEntidadeEnum.IDEIA, teste02user.Id));
        }
    }
}
