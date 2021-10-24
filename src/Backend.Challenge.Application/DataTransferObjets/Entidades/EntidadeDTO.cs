using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Application;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace Backend.Challenge.Application.DataTransferObjets
{
    public class EntidadeDTO : BaseDTO
    {
        public int TipoComentario { get; set; }

        public Guid UtilizadorId { get; set; }

        public IEnumerable<ComentarioDTO> Comentarios { get; set; }
    }
}
