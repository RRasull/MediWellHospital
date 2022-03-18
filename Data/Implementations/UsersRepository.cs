using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private AppDbContext _context { get; set; }
        public UsersRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
