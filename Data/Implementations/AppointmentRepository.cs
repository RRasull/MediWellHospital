using Core.Interfaces;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private AppDbContext _context { get; set; }
        public AppointmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
