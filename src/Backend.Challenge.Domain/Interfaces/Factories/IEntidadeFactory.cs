using Backend.Challenge.Domain.Entities;

namespace Backend.Challenge.Domain.Interfaces.Factories
{
    public interface IEntidadeFactory
    {
        EntidadeEntity Create(TipoEntidadeEnum tipoEntidade);
    }
}
