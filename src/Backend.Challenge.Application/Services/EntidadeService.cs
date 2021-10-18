using AutoMapper;
using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Application.Interfaces;
using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Domain.Interfaces.Repositories;
using Backend.Challenge.Kernel.Application;

namespace Backend.Challenge.Application.Services
{
    public class EntidadeService : BaseService<EntidadeDTO, EntidadeEntity>, IEntidadeService
    {
        public EntidadeService(IEntidadeRepository entidadeRepository, IMapper mapper)
            :base(entidadeRepository, mapper)
        {
        }
    }
}
