using Business.ViewModels;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Welcome = _context.Welcome.Where(w => w.IsDeleted == false).FirstOrDefault(),
                Cards =await _context.Cards.Where(c => c.IsDeleted == false).OrderByDescending(d => d.Id).Take(4).ToListAsync(),
                Departaments = await _context.Departaments.Where(d => d.IsDeleted == false).OrderByDescending(d=>d.Id).Take(8).ToListAsync(),
                Doctors = await _context.Doctors.Where(d => d.IsDeleted == false).ToListAsync()
            };
            return View(homeVM);
        }
    }
}
