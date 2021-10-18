using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Entities
{
    public class EntidadeEntity : BaseEntity, IAggregateRoot
    {
        public TipoEntidadeEnum TipoComentario { get; }
        public IEnumerable<ComentarioEntity> Comentarios { get; }
        public Guid UtilizadorId { get; }
        public UtilizadorEntity Utilizador { get; }

        internal EntidadeEntity(TipoEntidadeEnum tipoComentario, Guid utilizadorId)
        {
            this.TipoComentario = TipoComentario;
            this.UtilizadorId = utilizadorId;
        }

        public EntidadeEntity() { }
    }
}
