using Core.Interfaces;
using Core.Models;
using Data.DAL;

namespace Data.Implementations
{
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        private AppDbContext _context { get; set; }
        public ContactUsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
