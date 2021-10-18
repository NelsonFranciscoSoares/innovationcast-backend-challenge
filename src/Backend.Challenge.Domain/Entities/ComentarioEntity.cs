using Backend.Challenge.Kernel.Domain.Entities;
using System;

namespace Backend.Challenge.Domain.Entities
{
    public class ComentarioEntity : BaseEntity
    {
        public EntidadeEntity Entidade { get; }
        public Guid EntidadeId { get; }
        public string Texto { get; }
        public string Autor { get; }
        public DateTimeOffset DataPublicacao { get; }

        internal ComentarioEntity(Guid entidadeId, string texto, string autor)
        {
            this.EntidadeId = entidadeId;
            this.Texto = texto;
            this.Autor = autor;
            this.DataPublicacao = DateTimeOffset.UtcNow;
        }
    }
}
