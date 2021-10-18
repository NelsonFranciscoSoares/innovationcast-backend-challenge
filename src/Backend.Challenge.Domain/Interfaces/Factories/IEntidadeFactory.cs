using Backend.Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Domain.Interfaces.Factories
{
    public interface IEntidadeFactory
    {
        EntidadeEntity Create(TipoEntidadeEnum tipoEntidade, Guid utilizadorId);
    }
}
