using Backend.Challenge.Kernel.Application;
using System;

namespace Backend.Challenge.Application.DataTransferObjets
{
    public class ComentarioDTO : BaseDTO
    {
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTimeOffset DataPublicacao { get; set; }
    }
}
