using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Application.DataTransferObjets.Comentarios;
using Backend.Challenge.Application.DataTransferObjets.Comentarios.Criar;
using Backend.Challenge.Application.Interfaces;
using Backend.Challenge.Kernel.Application;
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

        public EntidadeController(IEntidadeService entidadeService,
            IValidationContext validationContext)
            :base(validationContext)
        {
            this._entidadeService = entidadeService;
        }

        [HttpPost("{entidadeId:guid}/adicionar-novo-comentario")]
        public async Task<ActionResult> AdicionaComentario(Guid entidadeId, CriarComentarioInputDTO criarComentarioDTO)
        {
            var criarComentarioOutputDTO = await this._entidadeService.AdicionarComentarioAsync(entidadeId, criarComentarioDTO);

            return RespostaPersonalizada<ResponseCriarComentarioDTO, CriarComentarioOutputDTO>(criarComentarioOutputDTO);
        }

        [HttpGet("{entidadeId:guid}/listar-comentarios")]
        public async Task<ActionResult> ListarComentarios(Guid entidadeId, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1)
        {
            var listaComentariosPorEntidade = await this._entidadeService.ObterComentariosPorEntidadePaginadoAsync(entidadeId, pageSize, pageIndex);

            return RespostaPersonalizada<ResponseListarComentariosDTO, PagedResultDTO<ListarComentariosOutputDTO>>(listaComentariosPorEntidade);
        }

        [HttpGet("{entidadeId:guid}/listar-comentarios-novos")]
        public async Task<ActionResult> ListarComentariosNovos(Guid entidadeId, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1)
        {
            var listaComentariosNovosPorEntidade = await this._entidadeService.ObterComentariosNovosPorEntidadePaginadoAsync(entidadeId, pageSize, pageIndex);

            return RespostaPersonalizada<ResponseListarComentariosNovosDTO, PagedResultDTO<ListarComentariosNovosOutputDTO>>(listaComentariosNovosPorEntidade);
        }
    }
}
