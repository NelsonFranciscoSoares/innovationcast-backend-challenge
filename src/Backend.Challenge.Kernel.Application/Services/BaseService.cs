using AutoMapper;
using Backend.Challenge.Kernel.Application.Services;

namespace Backend.Challenge.Kernel.Application
{
    public abstract class BaseService : IBaseService
    {
        protected IMapper _mapper;

        protected BaseService(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}
