using Backend.Challenge.Kernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Application.DataTransferObjets
{
    public class ComentarioDTO : BaseDTO
    {
        public string Texto { get; }
        public string Autor { get; }
        public DateTimeOffset DataPublicacao { get; }
    }
}
