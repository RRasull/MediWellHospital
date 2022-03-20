using Business.Interfaces;
using Business.ViewModels;
using Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    public class DepartamentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorService _doctorService;
        private readonly IDepartmentService _departmentService;


        public DepartamentController(IUnitOfWork unitOfWork, IDoctorService doctorService, IDepartmentService departmentService)
        {
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Welcome = await _unitOfWork.welcomeRepository.GetAsync(W => W.IsDeleted == false),
                Cards = await _unitOfWork.cardRepository.Take(4, c => c.IsDeleted == false),
                Departaments = await _unitOfWork.departmentRepository.GetAllAsync(d=>d.IsDeleted==false),
                Doctors = await _doctorService.GetAllAsync(),
                Setting = _unitOfWork.settingRepository.GetSetting()

            };
            return View(homeVM);
        }
    }
}
