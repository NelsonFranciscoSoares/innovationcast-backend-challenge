using Backend.Challenge.Kernel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.Domain.Entities
{
    public class ComentarioEntity : BaseEntity
    {
        public EntidadeEntity Entidade { get; private set; }
        public Guid EntidadeId { get; private set; }
        public string Texto { get; private set; }
        public string Autor { get; private set; }
        public DateTimeOffset DataPublicacao { get; private set; }
        public List<UtilizadorEntity> UtilizadoresVisualizaram{ get; private set; }

        internal ComentarioEntity(Guid entidadeId, string texto, string autor)
        {
            this.EntidadeId = entidadeId;
            this.Texto = texto;
            this.Autor = autor;
            this.DataPublicacao = DateTimeOffset.UtcNow;
            this.UtilizadoresVisualizaram = new List<UtilizadorEntity>();
        }

        public ComentarioEntity() { }

        public void AdicionaDataPublicacao()
        {
            this.DataPublicacao = DateTime.UtcNow;
        }

        public void AdicionaVisualizacao(params Guid [] utilizadoresIds)
        {
            if (this.UtilizadoresVisualizaram == null) this.UtilizadoresVisualizaram = new List<UtilizadorEntity>();

            utilizadoresIds.ToList().ForEach(utilizadorId => this.UtilizadoresVisualizaram.Add(new UtilizadorEntity(utilizadorId)));
        }
    }
}
