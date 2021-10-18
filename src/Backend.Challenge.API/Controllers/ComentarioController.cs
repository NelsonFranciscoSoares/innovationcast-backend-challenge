using Backend.Challenge.Application.DataTransferObjets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.API.Controllers
{
    [Route("api/entidade/{entidadeId:guid}/[controller]")]
    public class ComentarioController : BaseController
    {
        public ComentarioController() { }


        [HttpPost("adicionar-novo")]
        public Task AdicionaComentario(Guid entidadeId, ComentarioDTO comentarioDTO)
        {
            return Task.CompletedTask;
        }

        [HttpPut("actualizar-existente/{comentarioId:guid}")]
        public Task ActualizaComentario(Guid comentarioId)
        {
            return Task.CompletedTask;
        }

        [HttpDelete("remover/{comentarioId:guid}")]
        public Task ActualizaComentario(Guid entidadeId, Guid comentarioId)
        {
            return Task.CompletedTask;
        }

        [HttpGet("obter-comentarios")]
        public Task ObterComentario(Guid entidadeId, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1)
        {
            return Task.CompletedTask;
        }
    }
}
