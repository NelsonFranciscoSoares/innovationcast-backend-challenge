using Backend.Challenge.Application.DataTransferObjets;
using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Application.Interfaces
{
    public interface IEntidadeService : IBaseService<EntidadeDTO, EntidadeEntity>
    {
        Task<EntidadeDTO> AdicionarComentarioAsync(Guid entidadeId, ComentarioDTO comentarioDTO);
    }
}
