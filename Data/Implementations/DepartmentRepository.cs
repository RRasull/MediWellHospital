using Core.Interfaces;
using Core.Models;
using Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
   public class DepartmentRepository : Repository<Departament>, IDepartmentRepository

    {
        private AppDbContext _context { get; set; }
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
