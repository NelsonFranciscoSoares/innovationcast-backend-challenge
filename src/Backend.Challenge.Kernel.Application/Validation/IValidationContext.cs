using System.Collections.Generic;

namespace Backend.Challenge.Kernel.Application
{
    public interface IValidationContext
    {
        IReadOnlyList<string> ObterErros();
        void AdicionarErro(string mensagemErro);
        bool TemErros();
    }
}