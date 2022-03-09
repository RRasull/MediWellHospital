using Core.Interfaces;
using System.Threading.Tasks;

namespace Core
{
   public interface IUnitOfWork
    {
        public IDoctorRepository doctorRepository { get; }
        Task SaveAsync();
    }
}
