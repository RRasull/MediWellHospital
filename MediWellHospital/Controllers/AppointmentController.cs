using Business.Interfaces;
using Business.ViewModels;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IDoctorService _doctorService;
        private readonly IDepartmentService _departmentService;


        public AppointmentController(IUnitOfWork unitOfWork, IDoctorService doctorService, IDepartmentService departmentService)
        {
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;
            _departmentService = departmentService;
    }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Setting = _unitOfWork.settingRepository.GetSetting(),
                Departaments = await _unitOfWork.departmentRepository.GetAllAsync(d=>d.IsDeleted==false),
                Doctors =await _doctorService.GetAllAsync() 

            };
            return View(homeVM);
        }
    }
}
