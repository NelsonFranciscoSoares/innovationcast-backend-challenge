using System.Collections.Generic;

namespace Backend.Challenge.Kernel.Application.DataTransferObjects
{
    public abstract class ResponseBaseDTO<T>
    {
        public SucessoDTO<T> Sucesso { get; set; }
        public IEnumerable<ErroDTO> Erros { get; set; }
        public IEnumerable<AlertaDTO> Alertas { get; set; }
    }
}
