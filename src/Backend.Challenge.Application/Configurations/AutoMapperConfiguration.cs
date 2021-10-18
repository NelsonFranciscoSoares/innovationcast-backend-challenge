using AutoMapper;
using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Domain.Entities;

namespace Backend.Challenge.API.Configurations
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() {
            this.CreateMap<ComentarioDTO, ComentarioEntity>().ReverseMap();
            this.CreateMap<EntidadeDTO, EntidadeEntity>().ReverseMap();
        }
    }
}
