using AutoMapper;
using Business.ViewModels.DoctorVM;
using Core;
using Data.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]

    public class DoctorController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _env;
        private IMapper _mapper;

        public DoctorController(IUnitOfWork unitOfWork, IWebHostEnvironment env, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.doctorRepository.GetAllAsync(d => d.IsDeleted == false));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DoctorCreateUpdateVM createVM)
        {
            if (!ModelState.IsValid) return View();

            return View();
        }
    }
}
