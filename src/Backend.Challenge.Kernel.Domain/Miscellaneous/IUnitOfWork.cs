using System.Threading.Tasks;

namespace Backend.Challenge.Kernel.Domain.Miscellaneous
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
