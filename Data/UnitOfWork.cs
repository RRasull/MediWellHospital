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
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IDoctorRepository doctorRepository => _doctorRepository = _doctorRepository ?? new DoctorRepository(_context);



        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
