using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
   public class WelcomeRepository : Repository<Welcome>, IWelcomeRepository
    {
        private AppDbContext _context { get; set; }
        public WelcomeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
