using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
   public class PatientCommentRepository : Repository<PatientComment>, IPatientCommentRepository
    {
        private AppDbContext _context { get; set; }
        public PatientCommentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
