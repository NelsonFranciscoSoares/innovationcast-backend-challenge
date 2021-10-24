using Backend.Challenge.Kernel.Application;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IValidationContext _validationContext;

        protected BaseController(IValidationContext validationContext)
        {
            this._validationContext = validationContext;
        }

        protected bool OperacaoValida()
        {
            return !this._validationContext.TemErros();
        }

        protected ActionResult RespostaPersonalizada<T, TPayload>(TPayload result = default)
            where T : ResponseBaseDTO<TPayload>, new()
        {
            if (OperacaoValida())
            {
                return Ok(new T
                {
                    Sucesso = new SucessoDTO<TPayload>
                    {
                        DadosRetorno = result
                    }
                });
            }

            return BadRequest(new T
            {
                Erros = this._validationContext
                                .ObterErros()
                                .Select(erro => new ErroDTO { Codigo = "", Mensagem = erro })
            });
        }
    }
}
