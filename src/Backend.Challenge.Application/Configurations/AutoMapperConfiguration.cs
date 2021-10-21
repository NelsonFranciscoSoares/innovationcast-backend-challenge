using AutoMapper;
using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Backend.Challenge.Kernel.Domain;

namespace Backend.Challenge.API.Configurations
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() {
            this.CreateMap<ComentarioDTO, ComentarioEntity>().ReverseMap();
            this.CreateMap<EntidadeDTO, EntidadeEntity>().ReverseMap();
            this.CreateMap<PagedResultDTO<ComentarioDTO>, PagedResult<ComentarioEntity>>().ReverseMap();
        }
    }
}
