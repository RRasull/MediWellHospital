using AutoMapper;
using Business.Interfaces;
using Business.ViewModels.DepartmentVM;
using Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
        
    public class DepartmentController : Controller
    {



        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentService _departentService;

        private readonly Dictionary<string, string> _setting;

        public DepartmentController(IUnitOfWork unitOfWork, IDepartmentService departentService)
        {
            _unitOfWork = unitOfWork;
            _setting = _unitOfWork.settingRepository.GetSetting();
            _departentService = departentService;
        }
        public async Task<IActionResult> Index()
        {
           

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DepartmentCreateVM createVM)
        {
            await _departentService.CreateAsync(createVM);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            DepartmentUpdateVM departmentUpdateVM = _departentService.Update(id);
            return View(departmentUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DepartmentUpdateVM departmentUpdateVM)
        {
            if (!ModelState.IsValid) return View(departmentUpdateVM);
            if (!ModelState.IsValid) return View(departmentUpdateVM);
            if (id != departmentUpdateVM.Id) return BadRequest();
            var dbDepartment = await _unitOfWork.departmentRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbDepartment is null) return NotFound();

            await _departentService.UpdateAsync(id, departmentUpdateVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _departentService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
