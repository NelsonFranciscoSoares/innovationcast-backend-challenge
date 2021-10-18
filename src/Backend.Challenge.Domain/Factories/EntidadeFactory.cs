using Backend.Challenge.Domain.Entities;
using System;
using Backend.Challenge.Domain.Interfaces.Factories;

namespace Backend.Challenge.Domain.Factories
{
    public class EntidadeFactory : IEntidadeFactory
    {
        public EntidadeEntity Create(TipoEntidadeEnum tipoEntidade, Guid utilizadorId)
        {
            return new EntidadeEntity(tipoEntidade, utilizadorId);
        }

    }
}
