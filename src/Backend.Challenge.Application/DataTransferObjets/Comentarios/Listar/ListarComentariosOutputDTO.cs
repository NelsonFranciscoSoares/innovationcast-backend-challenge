using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Application.DataTransferObjets.Comentarios
{
    public class ListarComentariosOutputDTO : ComentarioDTO
    {
        public Guid EntidadeId { get; set; }

        public DateTimeOffset DataPublicacao { get; set; }
    }
}
