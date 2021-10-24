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

            modelBuilder.Entity<EntidadeEntity>().HasData(entidadeFactory.Create(TipoEntidadeEnum.IDEIA));
            modelBuilder.Entity<EntidadeEntity>().HasData(entidadeFactory.Create(TipoEntidadeEnum.SINAIS));
        }
    }
}
