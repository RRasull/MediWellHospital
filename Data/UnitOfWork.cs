using Core;
using Data.DAL;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
