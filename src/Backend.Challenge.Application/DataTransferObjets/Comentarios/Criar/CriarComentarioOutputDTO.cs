using System;

namespace Backend.Challenge.Application.DataTransferObjets.Comentarios
{
    public class CriarComentarioOutputDTO : ComentarioDTO
    {
        public Guid EntidadeId { get; set; }

        public DateTimeOffset DataPublicacao { get; set; }
    }
}
