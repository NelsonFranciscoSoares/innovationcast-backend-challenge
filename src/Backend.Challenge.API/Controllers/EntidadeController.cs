using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Application.Interfaces;
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
        public async Task<EntidadeDTO> AdicionaComentario(Guid entidadeId, ComentarioDTO comentarioDTO)
        {
            var entidadeDTO = await this._entidadeService.AdicionarComentarioAsync(entidadeId, comentarioDTO);

            return entidadeDTO;
        }
    }
}
