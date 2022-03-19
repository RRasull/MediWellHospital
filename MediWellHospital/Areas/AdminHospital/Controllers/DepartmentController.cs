using AutoMapper;
using Business.Interfaces;
using Business.Utilities.Helper;
using Business.ViewModels.DepartmentVM;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
    [Authorize(Roles ="Admin")]

    public class DepartmentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentService _departmentService;

        private readonly Dictionary<string, string> _setting;

        public DepartmentController(IUnitOfWork unitOfWork, IDepartmentService departmentService)
        {
            _unitOfWork = unitOfWork;
            _setting = _unitOfWork.settingRepository.GetSetting();
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
           
            return View(await _departmentService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DepartmentCreateVM createVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(createVM);
                await _departmentService.CreateAsync(createVM);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
            
        }

        public IActionResult Update(int id)
        {
            DepartmentUpdateVM departmentUpdateVM = _departmentService.Update(id);
            return View(departmentUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DepartmentUpdateVM departmentUpdateVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(departmentUpdateVM);
                //if (id != departmentUpdateVM.Id) return BadRequest();
                //var dbDepartment = await _unitOfWork.departmentRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
                //if (dbDepartment is null) return NotFound();

                await _departmentService.UpdateAsync(id, departmentUpdateVM);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _departmentService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
            

        }

    }
}
