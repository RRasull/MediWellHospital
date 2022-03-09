using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

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
