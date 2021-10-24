using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Kernel.Application.DataTransferObjects
{
    public class SucessoDTO<T>
    {
        public string Mensagem { get; set; }
        public T DadosRetorno { get; set; }
    }
}
