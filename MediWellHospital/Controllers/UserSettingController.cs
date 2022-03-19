using Business.Exceptions;
using Business.Utilities.Helper;
using Business.ViewModels.UserSettingVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    [Authorize]
    public class UserSettingController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;



        public UserSettingController(UserManager<User> userManager,
                                    SignInManager<User> signInManager,
                                    IWebHostEnvironment env,
                                    IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ChangeSetting()
        {
            ClaimsPrincipal currentUser = User;
            var user = await _userManager.GetUserAsync(User);
            UserSettingVM userSettingVM = new UserSettingVM
            {
                Username = user.UserName
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeSetting(UserSettingVM userSettingVM)
        {
            if (!ModelState.IsValid) return View(userSettingVM);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "İstifadəçi adı tapılmadı");
                return View(userSettingVM);
            }

            try
            {
                if (userSettingVM.Username != null)
                {
                    await ChangeUserName(user, userSettingVM);
                }
                if (userSettingVM.CurrentPassword != null && userSettingVM.NewPassword != null)
                {
                    await ChangePassword(user, userSettingVM);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(userSettingVM);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task ChangeUserName(User user, UserSettingVM userSettingVM)
        {
            var result = await _userManager.SetUserNameAsync(user, userSettingVM.Username);
            if (!result.Succeeded)
            {
                throw new SetUserNameException("Istifadəçi adı yanlışdır");
            }
            await _signInManager.RefreshSignInAsync(user);

        }

        public async Task ChangePassword(User User, UserSettingVM userSettingVM)
        {
            var result = await _userManager.ChangePasswordAsync(User, userSettingVM.CurrentPassword,
                                                                        userSettingVM.NewPassword);
            if (!result.Succeeded)
            {
                throw new SetPasswordException("Invalid Password");
            }
            await _signInManager.RefreshSignInAsync(User);

        }

        //public async Task ChangeImage(User user, UserSettingVM userSettingVM)
        //{

        //    if (!userSettingVM.ProfilePhoto.CheckContent("image/"))
        //    {
        //        throw new FileTypeException("Fayl şəkil formatında olmalıdır");
        //    }

        //    if (!userSettingVM.ProfilePhoto.CheckLength(2000))
        //    {
        //        throw new FileTypeException("Fayl 2mb-dan çox ola bilməz");
        //    }

        //    string fileName = await userSettingVM.ProfilePhoto.SaveFileAsync(_env.WebRootPath, "assets/images/Profile");

        //    userSettingVM.Image = fileName;

        //    await _unitOfWork..CreateAsync(department);
        //    await _unitOfWork.SaveAsync();
        //}
    }
}
