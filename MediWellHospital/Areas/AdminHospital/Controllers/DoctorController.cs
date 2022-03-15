using AutoMapper;
using Business.ViewModels.DoctorVM;
using Core;
using Core.Models;
using Data.DAL;
using Business.Utilities.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Core.Interfaces;
using Business.Interfaces;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]

    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IDoctorService _doctorService;


        public DoctorController(IUnitOfWork unitOfWork,  IWebHostEnvironment env, IDoctorService doctorService)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _doctorService = doctorService;
        }
        public async Task<IActionResult> Index()
        {
             
            return View(await _doctorService.GetAllAsync());

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DoctorCreateVM createVM)
        {
            if (!createVM.Photo.CheckContent("image/"))
            {
                ModelState.AddModelError("Photo", "Fayl şəkil formatında olmalıdır");
                return View();
            }

            if (!createVM.Photo.CheckLength(200))
            {
                ModelState.AddModelError("Photo", "Faylın ölçüsü 200 kb-dan az olmalıdır");
                return View();
            }


            //string fileName = await createVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Doctors");
            //Doctor doctor = _mapper.Map<Doctor>(createVM);

            //doctor.Image = fileName;


            //await _unitOfWork.doctorRepository.CreateAsync(doctor);
            //await _unitOfWork.SaveAsync();

            await _doctorService.CreateAsync(createVM);
 
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            DoctorUpdateVM doctorUpdateVM = _doctorService.Update(id);
            return View(doctorUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DoctorUpdateVM doctorUpdateVM)
        {
            if (!ModelState.IsValid) return View(doctorUpdateVM);
            if (id != doctorUpdateVM.Id) return BadRequest();
            var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbDoctor is null) return NotFound();

            if (!doctorUpdateVM.Photo.CheckContent("image/"))
            {
                ModelState.AddModelError("Photo", "Fayl şəkil formatında olmalıdır");
                return View();
            }

            if (!doctorUpdateVM.Photo.CheckLength(200))
            {
                ModelState.AddModelError("Photo", "Faylın ölçüsü 200 kb-dan az olmalıdır");
                return View();
            }

            //var oldPath = Path.Combine(_env.WebRootPath, "assets", "images", "Doctors", doctorVM.Photo.FileName);


            //if (System.IO.File.Exists(oldPath))
            //{
            //    System.IO.File.Delete(oldPath);
            //}

            //string fileName = await doctorVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Doctors");


            //dbDoctor.Name = doctorVM.Name;
            //dbDoctor.Surname = doctorVM.Surname;
            //dbDoctor.WorkingHours = doctorVM.WorkingHours;
            //dbDoctor.Description = doctorVM.Description;
            //dbDoctor.Address = doctorVM.Address;
            //dbDoctor.Education = doctorVM.Education;
            //dbDoctor.EmailAddress = doctorVM.EmailAddress;
            //dbDoctor.Fees = doctorVM.Fees;
            //dbDoctor.Gender = doctorVM.Gender;
            //dbDoctor.Splztion = doctorVM.Splztion;
            //dbDoctor.Phone = doctorVM.Phone;
            //dbDoctor.Departament = doctorVM.Departament;



            //dbDoctor.Image = fileName;

            //await _unitOfWork.SaveAsync();

            await _doctorService.UpdateAsync(id, doctorUpdateVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            //var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            //if (dbDoctor is null) return NotFound();


            //dbDoctor.Photo.RemoveFileAsync(_env.WebRootPath, "assets/images/Doctors", dbDoctor.Image);

            //dbDoctor.IsDeleted = true;

            //await _unitOfWork.SaveAsync();
            await _doctorService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
