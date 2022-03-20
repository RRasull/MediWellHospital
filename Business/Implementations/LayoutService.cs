using Core.Models;
using Data.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Business.Implementations
{
   public class LayoutService
    {
        public AppDbContext _context { get; }
        public LayoutService(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string, string> GetSetting()
        {
            return _context.Settings.AsEnumerable().ToDictionary(s=>s.Key,s=>s.Value);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
