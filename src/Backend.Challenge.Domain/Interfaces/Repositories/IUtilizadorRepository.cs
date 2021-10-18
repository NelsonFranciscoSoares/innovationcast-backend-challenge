using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Domain.Interfaces.Repositories
{
    public interface IUtilizadorRepository : IRepository<UtilizadorEntity>
    {
    }
}
