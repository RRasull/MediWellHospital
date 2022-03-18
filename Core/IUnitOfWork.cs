using Core.Interfaces;
using System.Threading.Tasks;

namespace Core
{
   public interface IUnitOfWork
    {
        public IDoctorRepository doctorRepository { get; }
        public ISettingRepository settingRepository { get; }
        public IDepartmentRepository departmentRepository { get; }
        public ICardRepository cardRepository { get; }
        public IWelcomeRepository welcomeRepository { get; }
        public IUsersRepository usersRepository { get; }
        public IPatientRepository patientRepository { get; }





        Task SaveAsync();
    }
}
