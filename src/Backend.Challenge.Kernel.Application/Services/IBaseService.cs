using Backend.Challenge.Kernel.Domain;
using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.Kernel.Application.Services
{
    public interface IBaseService<TDto, TEntity>
        where TDto : BaseDTO
        where TEntity : BaseEntity, IAggregateRoot
    {
        Task<TDto> AdicionarAsync(TDto inputDTO);
        Task<TDto> ActualizarAsync(TDto inputDTO);
        Task<PagedResult<TDto>> ObterTodosPaginadoAsync(int pageSize, int pageIndex);
        Task<TDto> ObterPorIdAsync(Guid id);
        Task RemoverAsync(Guid id);
    }
}
