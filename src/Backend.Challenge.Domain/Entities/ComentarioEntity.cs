using Backend.Challenge.Kernel.Domain.Entities;
using System;

namespace Backend.Challenge.Domain.Entities
{
    public class ComentarioEntity : BaseEntity
    {
        public EntidadeEntity Entidade { get; private set; }
        public Guid EntidadeId { get; private set; }
        public string Texto { get; private set; }
        public string Autor { get; private set; }
        public DateTimeOffset DataPublicacao { get; private set; }

        internal ComentarioEntity(Guid entidadeId, string texto, string autor)
        {
            this.EntidadeId = entidadeId;
            this.Texto = texto;
            this.Autor = autor;
            this.DataPublicacao = DateTimeOffset.UtcNow;
        }

        public ComentarioEntity() { }

        public void AdicionaDataPublicacao()
        {
            this.DataPublicacao = DateTime.UtcNow;
        }
    }
}
