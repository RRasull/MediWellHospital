using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Implementations
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private AppDbContext _context { get; set; }
        public SettingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Dictionary<string, string> GetSetting()
        {
            return _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
