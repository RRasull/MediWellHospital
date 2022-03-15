using Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    public class DepartamentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IDepartamentService _doctorService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
