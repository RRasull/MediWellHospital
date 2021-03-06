using Business.Exceptions;
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
using System;
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
        private readonly IPatientService _patientService;

        private readonly AppDbContext _context;



        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public PatientController(IUnitOfWork unitOfWork,
                                IWebHostEnvironment env,
                                IPatientService patientService,
                                UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _patientService.GetAllAsync());

        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(PatientCreateIdentityVM patientCreateIdentityVM)
        {
            if (!ModelState.IsValid) return View(patientCreateIdentityVM);

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
            //if (!ModelState.IsValid) return View(patientUpdateVM);
            //if (id != patientUpdateVM.Id) return BadRequest();
            //var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            //if (dbDoctor is null) return NotFound();

            //if (!patientUpdateVM.Photo.CheckContent("image/"))
            //{
            //    ModelState.AddModelError("Photo", "Fayl şəkil formatında olmalıdır");
            //    return View();
            //}

            //if (!patientUpdateVM.Photo.CheckLength(2000))
            //{
            //    ModelState.AddModelError("Photo", "Faylın ölçüsü 2 mb-dan az olmalıdır");
            //    return View();
            //}


            //await _patientService.UpdateAsync(id, patientUpdateVM);

            //return RedirectToAction(nameof(Index));

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
            
            //User dbUser = await _userManager.FindByIdAsync(user.Id);

            var dbPatient = await _unitOfWork.patientRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            var user = await _userManager.FindByEmailAsync(dbPatient.EmailAddress);

            if (dbPatient is null) throw new NotFoundException("Patient Not Found While Remove ");


            dbPatient.Photo.RemoveFileAsync(_env.WebRootPath, "assets/images/Patients", dbPatient.Image);

            dbPatient.IsDeleted = true;
            _unitOfWork.usersRepository.Remove(user);

            await _userManager.DeleteAsync(user);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
