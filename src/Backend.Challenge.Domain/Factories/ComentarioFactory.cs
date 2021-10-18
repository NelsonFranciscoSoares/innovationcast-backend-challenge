using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Interfaces.Factories;
using System;

namespace Backend.Challenge.Domain.Factories
{
    public class ComentarioFactory : IComentarioFactory
    {
        public ComentarioEntity Create(Guid entidadeId, string texto, string autor)
        {
            return new ComentarioEntity(entidadeId, texto, autor);
        }
    }
}
