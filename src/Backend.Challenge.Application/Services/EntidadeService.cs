using AutoMapper;
using Backend.Challenge.Application.DataTransferObjets.Comentarios;
using Backend.Challenge.Application.DataTransferObjets.Comentarios.Criar;
using Backend.Challenge.Application.Interfaces;
using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Interfaces.Repositories;
using Backend.Challenge.Kernel.Application;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.Application.Services
{
    public class EntidadeService : BaseService, IEntidadeService
    {
        private readonly IEntidadeRepository _entidadeRepository;
        private readonly UtilizadorEntity _utilizadorContexto;

        public EntidadeService(IEntidadeRepository entidadeRepository, IMapper mapper, IOptions<UtilizadorEntity> utilizadorContexto)
            :base(mapper)
        {
            this._entidadeRepository = entidadeRepository;
            this._utilizadorContexto = utilizadorContexto.Value;
        }

        public async Task<CriarComentarioOutputDTO> AdicionarComentarioAsync(Guid entidadeId, CriarComentarioInputDTO comentarioInputDTO)
        {
            //Validação aqui
            if(comentarioInputDTO.EntidadeId != entidadeId)
            {
                // retorna mensagem de erro
            }

            comentarioInputDTO.EntidadeId = entidadeId;
            var entidadeEntity = await this._entidadeRepository.ObterPorIdAsync(entidadeId);

            var comentarioEntity = this._mapper.Map<ComentarioEntity>(comentarioInputDTO);

            entidadeEntity.AdicionarComentario(comentarioEntity);

            var entidadeEntityPersistida = await this._entidadeRepository.ActualizarAsync(entidadeEntity);
            await this._entidadeRepository.UnitOfWork.Commit();

            return this._mapper.Map<CriarComentarioOutputDTO>(comentarioEntity);
        }

        public async Task<PagedResultDTO<ListarComentariosNovosOutputDTO>> ObterComentariosNovosPorEntidadePaginadoAsync(Guid entidadeId, int pageSize, int pageIndex)
        {
            var resultadoPaginado = await this._entidadeRepository.ObterComentariosNovosPorEntidadePaginadoAsync(entidadeId,_utilizadorContexto.Id, pageSize, pageIndex);

            return this._mapper.Map<PagedResultDTO<ListarComentariosNovosOutputDTO>>(resultadoPaginado);
        }

        public async Task<PagedResultDTO<ListarComentariosOutputDTO>> ObterComentariosPorEntidadePaginadoAsync(Guid entidadeId, int pageSize, int pageIndex)
        {
            var resultadoPaginado = await this._entidadeRepository.ObterComentariosPorEntidadePaginadoAsync(entidadeId, pageSize, pageIndex);

            return this._mapper.Map<PagedResultDTO<ListarComentariosOutputDTO>>(resultadoPaginado);
        }
    }
}
