using Backend.Challenge.Domain.Entities;
using System;

namespace Backend.Challenge.Domain.Factories
{
    public static  class ComentarioFactory
    {
        public static ComentarioEntity Create(Guid entidadeId, string texto, string autor)
        {
            return new ComentarioEntity(entidadeId, texto, autor);
        }
    }
}
