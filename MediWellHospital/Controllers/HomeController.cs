using Business.ViewModels;
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

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Welcome = await _unitOfWork.welcomeRepository.GetAsync(W=>W.IsDeleted==false),
                Cards = await _unitOfWork.cardRepository.Take(4,c=>c.IsDeleted==false),
                Departaments = await _unitOfWork.departmentRepository.Take(8,d=>d.IsDeleted==false),
                Doctors = await _unitOfWork.doctorRepository.GetAllAsync(d=>d.IsDeleted==false),
                Setting = _unitOfWork.settingRepository.GetSetting()



            };
            return View(homeVM);
        }
    }
}
