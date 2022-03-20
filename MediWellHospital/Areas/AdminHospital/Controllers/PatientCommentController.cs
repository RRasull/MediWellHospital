using Business.Interfaces;
using Business.ViewModels.PatientCommentVM;
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
    [Authorize(Roles = "Admin")]
    public class PatientCommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientCommentService _patientCommentService;

        public PatientCommentController(IUnitOfWork unitOfWork, IPatientCommentService patientCommentService)
        {
            _unitOfWork = unitOfWork;
            _patientCommentService = patientCommentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _patientCommentService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(PatientCommentCreateVM createVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(createVM);
                await _patientCommentService.CreateAsync(createVM);
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
            PatientCommentUpdateVM patientCommentUpdateVM = _patientCommentService.Update(id);
            return View(patientCommentUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PatientCommentUpdateVM updateVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(updateVM);

                await _patientCommentService.UpdateAsync(id, updateVM);

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
                await _patientCommentService.RemoveAsync(id);
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
