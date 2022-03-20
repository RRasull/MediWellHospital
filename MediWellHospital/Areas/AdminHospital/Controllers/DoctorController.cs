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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Business.Utilities.Email;
using static Business.Utilities.Helper.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business.Exceptions;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
    [Authorize(Roles ="Admin")]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IDoctorService _doctorService;
        private readonly ISettingService _settingService;



        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public DoctorController(IUnitOfWork unitOfWork,
                                IWebHostEnvironment env,
                                IDoctorService doctorService,
                                ISettingService settingService,
                                UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _doctorService = doctorService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _doctorService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View(await _doctorService.Create());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DoctorCreateIdentityVM doctorCreateIdentityVM)
        {
            if (!ModelState.IsValid) return View(doctorCreateIdentityVM);
            var departaments = await _unitOfWork.departmentRepository.GetAllAsync();

            doctorCreateIdentityVM.Departaments = departaments;

            
            if (!doctorCreateIdentityVM.Photo.CheckContent("image/"))
            {
                ModelState.AddModelError("Photo", "Fayl şəkil formatında olmalıdır");
                return View(doctorCreateIdentityVM);
            }

            if (!doctorCreateIdentityVM.Photo.CheckLength(2000))
            {
                ModelState.AddModelError("Photo", "Faylın ölçüsü 2 mb-dan az olmalıdır");
                return View(doctorCreateIdentityVM);
            }

            
            User user = new User()
            {
                UserName = doctorCreateIdentityVM.Username,
                Email = doctorCreateIdentityVM.Email

            };

            User userEmail = await _userManager.FindByEmailAsync(user.Email);

            if (userEmail != null)
            {
                ModelState.AddModelError(string.Empty, "Bu e-poçtla qeydiyyatdan keçə bilməzsiniz, çünki o, artıq mövcuddur");
                return View(doctorCreateIdentityVM);
            }


            var identityResult = await _userManager.CreateAsync(user, doctorCreateIdentityVM.Password);


            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
                return View(doctorCreateIdentityVM);
            }

            await _userManager.AddToRoleAsync(user, UserRoles.Doctor.ToString());

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "EmailAdmin", new { token, email = doctorCreateIdentityVM.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper();

            await _doctorService.CreateAsync(doctorCreateIdentityVM);
            
 
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            DoctorUpdateVM doctorUpdateVM = await _doctorService.Update(id);
            return View(doctorUpdateVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DoctorUpdateVM doctorUpdateVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(doctorUpdateVM);
                //if (id != doctorUpdateVM.Id) return BadRequest();
                //var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
                //if (dbDoctor is null) return NotFound();

                //var departaments = await _unitOfWork.departmentRepository.GetAllAsync();

                //DoctorCreateIdentityVM doctorCreate = new DoctorCreateIdentityVM
                //{
                //    Departaments = departaments
                //};

                await _doctorService.UpdateAsync(id, doctorUpdateVM);

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
            var user = await _userManager.GetUserAsync(User);
            User dbUser = await _userManager.FindByIdAsync(user.Id);

            var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);


            if (dbDoctor is null) throw new NotFoundException("Doctor Not Found While Remove ");


            dbDoctor.Photo.RemoveFileAsync(_env.WebRootPath, "assets/images/Doctors", dbDoctor.Image);

            dbDoctor.IsDeleted = true;
            _unitOfWork.usersRepository.Remove(dbUser);

            await _userManager.DeleteAsync(dbUser);

            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

    }

}
