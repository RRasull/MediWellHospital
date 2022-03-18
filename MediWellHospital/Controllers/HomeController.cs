using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.AppointmentVM;
using Core;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorService _doctorService;



        public HomeController(IUnitOfWork unitOfWork, IDoctorService doctorService)
        {
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;

        }
        public async Task<IActionResult> Index()
        {
            AppointCreateVM appointVM = new AppointCreateVM();
            HomeVM homeVM = new HomeVM
            {
                Welcome = await _unitOfWork.welcomeRepository.GetAsync(W => W.IsDeleted == false),
                Cards = await _unitOfWork.cardRepository.Take(4, c => c.IsDeleted == false),
                Departaments = await _unitOfWork.departmentRepository.Take(8, d => d.IsDeleted == false),
                Doctors = await _doctorService.GetAllAsync(),
                Setting = _unitOfWork.settingRepository.GetSetting()
            };
            return View(homeVM);
        }

        //public async Task<IActionResult> Create()
        //{

        //}
    }
}
