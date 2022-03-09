using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]

    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
