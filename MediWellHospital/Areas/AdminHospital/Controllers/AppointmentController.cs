using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
    [Authorize(Roles = "Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _appointmentService.GetAllAsync());
        }


    }
}
