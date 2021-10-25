using Backend.Challenge.Kernel.Application;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        private bool OperacaoValida()
        {
            return !this._validationContext.TemErros();
        }

        private void AdicionarErroProcessamento(string erro)
        {
            this._validationContext.AdicionarErro(erro);
        }

        protected ActionResult RespostaPersonalizada<T, TPayload>(ModelStateDictionary modelState)
            where T : ResponseBaseDTO<TPayload>, new()
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return RespostaPersonalizada<T,TPayload>();
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
