using AutoMapper;
using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Application.Interfaces;
using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Interfaces.Repositories;
using Backend.Challenge.Kernel.Application;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.Application.Services
{
    public class EntidadeService : BaseService<EntidadeDTO, EntidadeEntity>, IEntidadeService
    {
        public EntidadeService(IEntidadeRepository entidadeRepository, IMapper mapper)
            :base(entidadeRepository, mapper)
        {
        }

        public async Task<EntidadeDTO> AdicionarComentarioAsync(Guid entidadeId, ComentarioDTO comentarioDTO)
        {
            var entidadeEntity = await this._genericRepository.ObterPorIdAsync(entidadeId);

            var comentarioEntity = this._mapper.Map<ComentarioEntity>(comentarioDTO);

            entidadeEntity.AdicionarComentario(comentarioEntity);

            var entidadeEntityPersistida = await this._genericRepository.ActualizarAsync(entidadeEntity);
            await this._genericRepository.UnitOfWork.Commit();

            return this._mapper.Map<EntidadeDTO>(entidadeEntityPersistida);
        }
    }
}
