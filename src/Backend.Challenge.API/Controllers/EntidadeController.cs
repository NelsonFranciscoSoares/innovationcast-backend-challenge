using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Application.DataTransferObjets.Comentarios;
using Backend.Challenge.Application.Interfaces;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    public class EntidadeController : BaseController
    {
        private IEntidadeService _entidadeService;

        public EntidadeController(IEntidadeService entidadeService)
        {
            this._entidadeService = entidadeService;
        }

        [HttpPost("{entidadeId:guid}/adicionar-novo-comentario")]
        public async Task<ResponseCriarComentarioDTO> AdicionaComentario(Guid entidadeId, RequestCriarComentarioDTO requestCriarComentarioDTO)
        {
            var criarComentarioOutputDTO = await this._entidadeService.AdicionarComentarioAsync(entidadeId, requestCriarComentarioDTO.DadosEntrada);

            return new ResponseCriarComentarioDTO { 
                Sucesso = new SucessoDTO<CriarComentarioOutputDTO> {
                    Mensagem = "Comentário adicionado com sucesso",
                    DadosRetorno = criarComentarioOutputDTO
                }
            };
        }

        [HttpGet("{entidadeId:guid}/listar-comentarios")]
        public async Task<ResponseListarComentariosDTO> ListarComentarios(Guid entidadeId, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1)
        {
            var listaComentariosPorEntidade = await this._entidadeService.ObterComentariosPorEntidadePaginadoAsync(entidadeId, pageSize, pageIndex);

            return new ResponseListarComentariosDTO
            {
                Sucesso = new SucessoDTO<PagedResultDTO<ListarComentariosOutputDTO>>
                {
                    DadosRetorno = listaComentariosPorEntidade,
                    Mensagem = "Obtida lista de comentários por entidade"
                }
            };
        }

        [HttpGet("{entidadeId:guid}/listar-comentarios-novos")]
        public async Task<ResponseListarComentariosNovosDTO> ListarComentariosNovos(Guid entidadeId, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1)
        {
            var listaComentariosNovosPorEntidade = await this._entidadeService.ObterComentariosNovosPorEntidadePaginadoAsync(entidadeId, pageSize, pageIndex);

            return new ResponseListarComentariosNovosDTO
            {
                Sucesso = new SucessoDTO<PagedResultDTO<ListarComentariosNovosOutputDTO>>
                {
                    DadosRetorno = listaComentariosNovosPorEntidade,
                    Mensagem = "Obtida lista de comentários por entidade"
                }
            };
        }
    }
}
