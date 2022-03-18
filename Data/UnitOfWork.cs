using Core;
using Core.Interfaces;
using Data.DAL;
using Data.Implementations;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context { get; }
        private IDoctorRepository _doctorRepository;
        private ISettingRepository _settingRepository;
        private IDepartmentRepository _departmentRepository;
        private ICardRepository _cardRepository;
        private IWelcomeRepository _welcomeRepository;
        private IUsersRepository _userRepository;
        private IPatientRepository _patientRepository;



        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IDoctorRepository doctorRepository => _doctorRepository = _doctorRepository ?? new DoctorRepository(_context);
        public ISettingRepository settingRepository => _settingRepository = _settingRepository ?? new SettingRepository(_context);
        public IDepartmentRepository departmentRepository => _departmentRepository = _departmentRepository ?? new DepartmentRepository(_context);
        public ICardRepository cardRepository => _cardRepository = _cardRepository ?? new CardRepository(_context);
        public IWelcomeRepository welcomeRepository => _welcomeRepository = _welcomeRepository ?? new WelcomeRepository(_context);
        public IPatientRepository patientRepository => _patientRepository = _patientRepository ?? new PatientRepository(_context);

        public IUsersRepository usersRepository => _userRepository = _userRepository ?? new UsersRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
