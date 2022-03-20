using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.AppointmentVM;
using Business.ViewModels.DepartmentVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IAppointmentService _appointmentService;


        private readonly UserManager<User> _userManager;



        public AppointmentController(IUnitOfWork unitOfWork,
                                    IDoctorService doctorService,
                                    IDepartmentService departmentService,
                                    UserManager<User> userManager,
                                    IAppointmentService appointmentService)
        {
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;
            _departmentService = departmentService;
            _appointmentService = appointmentService;

            _userManager = userManager;
    }
        //public async Task<IActionResult> Index()
        //{
        //    AppointCreateVM appointCreateVM = new AppointCreateVM();
        //    AppointmentVM appointmentVM = new AppointmentVM
        //    {
        //        Departaments = await _unitOfWork.departmentRepository.GetAllAsync(d => d.IsDeleted == false),
        //        Doctors = await _doctorService.GetAllAsync(),
        //        AppointCreateVM = appointCreateVM
        //    };
        //    return View(appointmentVM);
        //}

        public async Task<IActionResult> Create()
        {

            var doctors = await _unitOfWork.doctorRepository.GetAllAsync(d=>d.IsDeleted==false);
            AppointCreateVM createDto = new AppointCreateVM
            {
                User = await _userManager.GetUserAsync(User),
                Doctors = doctors

            };

            return View(createDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointCreateVM createVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(createVM);
                await _appointmentService.CreateAsync(createVM);
                return RedirectToAction("SentSuccessfully", "Appointment");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(createVM);
            }
        }

        public IActionResult SentSuccessfully()
        {
            return View();
        }

    }
}
