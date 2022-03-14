using System.Threading.Tasks;

namespace Core
{
   public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
