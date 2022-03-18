using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
   public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private AppDbContext _context { get; set; }
        public PatientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
