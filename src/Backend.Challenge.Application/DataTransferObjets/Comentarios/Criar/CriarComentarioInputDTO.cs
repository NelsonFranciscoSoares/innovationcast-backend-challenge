using System;

namespace Backend.Challenge.Application.DataTransferObjets.Comentarios.Criar
{
    public class CriarComentarioInputDTO : ComentarioDTO
    {
        public Guid EntidadeId { get; set; }
    }
}
