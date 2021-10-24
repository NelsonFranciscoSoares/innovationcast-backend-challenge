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
        public List<UtilizadorEntity> Visualizado_Por { get; private set; }

        internal ComentarioEntity(Guid entidadeId, string texto, string autor)
        {
            this.EntidadeId = entidadeId;
            this.Texto = texto;
            this.Autor = autor;
            this.DataPublicacao = DateTimeOffset.UtcNow;
            this.Visualizado_Por = new List<UtilizadorEntity>();
        }

        public ComentarioEntity() { }

        public void AdicionaDataPublicacao()
        {
            this.DataPublicacao = DateTime.UtcNow;
        }

        public void AdicionaVisualizacao(params Guid [] utilizadoresIds)
        {
            if (this.Visualizado_Por == null) this.Visualizado_Por = new List<UtilizadorEntity>();

            utilizadoresIds.ToList().ForEach(utilizadorId => this.Visualizado_Por.Add(new UtilizadorEntity(utilizadorId)));
        }
    }
}
