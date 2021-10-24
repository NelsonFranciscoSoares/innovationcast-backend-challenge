using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Application.DataTransferObjets.Comentarios;
using Backend.Challenge.Application.DataTransferObjets.Comentarios.Criar;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Backend.Challenge.Kernel.Application.Services;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.Application.Interfaces
{
    public interface IEntidadeService : IBaseService
    {
        Task<CriarComentarioOutputDTO> AdicionarComentarioAsync(Guid entidadeId, CriarComentarioInputDTO comentarioDTO);

        Task<PagedResultDTO<ListarComentariosOutputDTO>> ObterComentariosPorEntidadePaginadoAsync(Guid entidadeId, int pageSize, int pageIndex);

        Task<PagedResultDTO<ListarComentariosNovosOutputDTO>> ObterComentariosNovosPorEntidadePaginadoAsync(Guid id, int pageSize, int pageIndex);
    }
}
