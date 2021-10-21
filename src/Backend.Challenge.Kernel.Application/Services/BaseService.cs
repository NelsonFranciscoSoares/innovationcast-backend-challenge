using AutoMapper;
using Backend.Challenge.Kernel.Application.Services;
using Backend.Challenge.Kernel.Domain;
using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using Backend.Challenge.Kernel.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Challenge.Kernel.Application
{
    public abstract class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity>
        where TDto : BaseDTO 
        where TEntity : BaseEntity, IAggregateRoot
    {
        protected IRepository<TEntity> _genericRepository;
        protected IMapper _mapper;

        protected BaseService(IRepository<TEntity> genericRepository, IMapper mapper)
        {
            this._genericRepository = genericRepository;
            this._mapper = mapper;
        }

        public async Task<PagedResult<TDto>> ObterTodosPaginadoAsync(int pageSize, int pageIndex)
        {
            var entidades = await this._genericRepository.ObterTodosPaginadoAsync(pageSize, pageIndex);

            return new PagedResult<TDto>
            {
                //TO DO: Melhorar aqui
                Items = this._mapper.Map<IEnumerable<TDto>>(entidades?.Items),
                PageIndex = entidades.PageIndex,
                PageSize = entidades.PageSize,
                TotalResults = entidades.TotalResults
            };
        }

        public async Task<TDto> AdicionarAsync(TDto inputDTO)
        {
            var entidadeDominio = this._mapper.Map<TEntity>(inputDTO);

            var entidadeDominioPersistida = await this._genericRepository.AdicionarAsync(entidadeDominio);

            await this._genericRepository.UnitOfWork.Commit();

            var outputDTO = this._mapper.Map<TDto>(entidadeDominioPersistida);

            return outputDTO;
        }

        public async Task<TDto> ActualizarAsync(TDto inputDTO)
        {
            var entidadeDominio = this._mapper.Map<TEntity>(inputDTO);

            var entidadeDominioPersistida = await this._genericRepository.ActualizarAsync(entidadeDominio);

            await this._genericRepository.UnitOfWork.Commit();

            var outputDTO = this._mapper.Map<TDto>(entidadeDominioPersistida);

            return outputDTO;
        }

        public async Task RemoverAsync(Guid id)
        {
            await this._genericRepository.RemoverAsync(id);
            await this._genericRepository.UnitOfWork.Commit();
        }

        public async Task<TDto> ObterPorIdAsync(Guid id)
        {
            var entidadeDominioPersistida = await this._genericRepository.ObterPorIdAsync(id);

            var outputDTO = this._mapper.Map<TDto>(entidadeDominioPersistida);

            return outputDTO;
        }
    }
}
