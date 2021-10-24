using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.Kernel.Application.ErrorContext
{
    public class ValidationContext : IValidationContext
    {
        private List<string> _erros;

        public ValidationContext()
        {
            this._erros = new List<string>();
        }

        public IReadOnlyList<string> ObterErros()
        {
            return this._erros.AsReadOnly();
        }

        public void AdicionarErro(string mensagemErro)
        {
            this._erros.Add(mensagemErro);
        }

        public bool TemErros()
        {
            return this._erros.Any();
        }
    }
}
