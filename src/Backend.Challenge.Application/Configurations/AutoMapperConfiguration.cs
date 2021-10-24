using AutoMapper;
using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Application.DataTransferObjets.Comentarios;
using Backend.Challenge.Application.DataTransferObjets.Comentarios.Criar;
using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Factories;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Backend.Challenge.Kernel.Domain;

namespace Backend.Challenge.API.Configurations
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() {
            this.CreateMap<CriarComentarioInputDTO, ComentarioEntity>()
                    .ConstructUsing(inputDTO => ComentarioFactory.Create(inputDTO.EntidadeId, inputDTO.Texto, inputDTO.Autor));
            this.CreateMap<ComentarioEntity, CriarComentarioOutputDTO>();
            this.CreateMap<PagedResult<ComentarioEntity>, PagedResultDTO<ListarComentariosOutputDTO>>();
            this.CreateMap<ComentarioEntity, ListarComentariosOutputDTO>();
        }
    }
}
