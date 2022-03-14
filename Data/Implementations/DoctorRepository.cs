using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
   public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private AppDbContext _context { get; set; }
        public DoctorRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
