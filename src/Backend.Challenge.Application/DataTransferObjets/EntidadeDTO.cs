using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Application;
using System;
using System.Collections.Generic;

namespace Backend.Challenge.Application.DataTransferObjets
{
    public class EntidadeDTO : BaseDTO
    {
        public TipoEntidadeEnum TipoComentario { get; }

        public Guid UtilizadorId { get; }

        public IEnumerable<ComentarioDTO> Comentarios { get; }
    }
}
