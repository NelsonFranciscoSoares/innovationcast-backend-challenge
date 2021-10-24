using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Entities
{
    public class EntidadeEntity : BaseEntity, IAggregateRoot
    {
        public TipoEntidadeEnum TipoComentario { get; private set; }
        public List<ComentarioEntity> Comentarios { get; private set; }

        internal EntidadeEntity(TipoEntidadeEnum tipoComentario)
        {
            this.TipoComentario = tipoComentario;
        }

        public EntidadeEntity() { }

        public void AdicionarComentario(ComentarioEntity comentarioEntity)
        {
            if (this.Comentarios == null) this.Comentarios = new List<ComentarioEntity>();

            comentarioEntity.AdicionaDataPublicacao();

            this.Comentarios.Add(comentarioEntity);
        }
    }
}
