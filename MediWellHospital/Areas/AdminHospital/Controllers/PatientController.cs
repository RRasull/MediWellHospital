using Business.Interfaces;
using Business.Utilities.Email;
using Business.Utilities.Helper;
using Business.ViewModels.PatientVM;
using Core;
using Core.Models;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Business.Utilities.Helper.Helper;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
    [Authorize(Roles = "Admin")]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        private readonly AppDbContext _context;



        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public PatientController(IUnitOfWork unitOfWork,
                                IWebHostEnvironment env,
                                IDoctorService doctorService,
                                IPatientService patientService,
                                UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _doctorService = doctorService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _doctorService.GetAllAsync());

        }

        public async Task<IActionResult> Create()
        {
            await GetSelectedItemAsync();
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(PatientCreateIdentityVM patientCreateIdentityVM)
        {
            await GetSelectedItemAsync();
            if (!patientCreateIdentityVM.Photo.CheckContent("image/"))
            {
                ModelState.AddModelError("Photo", "Fayl şəkil formatında olmalıdır");
                return View();
            }

            if (!patientCreateIdentityVM.Photo.CheckLength(2000))
            {
                ModelState.AddModelError("Photo", "Faylın ölçüsü 2 mb-dan az olmalıdır");
                return View();
            }

            if (!ModelState.IsValid) return View(patientCreateIdentityVM);

            User user = new User()
            {
                UserName = patientCreateIdentityVM.Username,
                Email = patientCreateIdentityVM.Email

            };

            User userEmail = await _userManager.FindByEmailAsync(user.Email);

            if (userEmail != null)
            {
                ModelState.AddModelError(string.Empty, "Bu e-poçtla qeydiyyatdan keçə bilməzsiniz, çünki o, artıq mövcuddur");
                return View();
            }



            var identityResult = await _userManager.CreateAsync(user, patientCreateIdentityVM.Password);


            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
                return View(patientCreateIdentityVM);
            }

            await _userManager.AddToRoleAsync(user, UserRoles.Patient.ToString());

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "EmailAdmin", new { token, email = patientCreateIdentityVM.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper();

            await _patientService.CreateAsync(patientCreateIdentityVM);



            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            PatientUpdateVM patientUpdateVM = _patientService.Update(id);
            return View(patientUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PatientUpdateVM patientUpdateVM)
        {
            if (!ModelState.IsValid) return View(patientUpdateVM);
            if (id != patientUpdateVM.Id) return BadRequest();
            var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbDoctor is null) return NotFound();

            if (!patientUpdateVM.Photo.CheckContent("image/"))
            {
                ModelState.AddModelError("Photo", "Fayl şəkil formatında olmalıdır");
                return View();
            }

            if (!patientUpdateVM.Photo.CheckLength(2000))
            {
                ModelState.AddModelError("Photo", "Faylın ölçüsü 2 mb-dan az olmalıdır");
                return View();
            }


            await _patientService.UpdateAsync(id, patientUpdateVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task GetSelectedItemAsync()
        {
            ViewBag.Departments = new SelectList(await _context.Departaments
                                                .Where(d => d.IsDeleted == false)
                                                .ToListAsync(), "Id", "Name");
        }
    }
}
