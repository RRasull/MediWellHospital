using Business.ViewModels.Auth;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
                                      SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);

            User user = new User()
            {
                UserName = register.Username,
                Email = register.Email

            };

            var userEmail = await _userManager.FindByEmailAsync(user.Email);

            if (userEmail != null)
            {
                ModelState.AddModelError(string.Empty, "you cannot register with this email because it is  already exist");
                return View();
            }

            //if (userEmail.Email == register.Email)
            //{
            //    ModelState.AddModelError("Email", "Email has already been registered");
            //    return View(register);
            //}

            var identityResult = await _userManager.CreateAsync(user, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
                return View(register);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            var user = await _userManager.FindByEmailAsync(login.Email);

            var identityUser = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);

            if (!identityUser.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Email or password is wrong");
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult GoogleLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("SocialMediaResponse", "Account", new { returnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        public async Task<IActionResult> SocialMediaResponse(string returnUrl)
        {
            var loginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Register");
            }
            else
            {
                var result =
                    await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (loginInfo.Principal.HasClaim(scl => scl.Type == ClaimTypes.Email))
                    {
                        User user = new User()
                        {
                            Email = loginInfo.Principal.FindFirstValue(ClaimTypes.Email),
                            Fullname = loginInfo.Principal.FindFirstValue(ClaimTypes.Name),
                            UserName = loginInfo.Principal.FindFirstValue(ClaimTypes.Surname)
                        };
                        var createResult = await _userManager.CreateAsync(user);
                        if (createResult.Succeeded)
                        {
                            var identityLogin = await _userManager.AddLoginAsync(user, loginInfo);
                            if (identityLogin.Succeeded)
                            {
                                await _signInManager.SignInAsync(user, true);
                                return Redirect("Login");
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Register");
        }




        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ForgotPassword([Required] string email)
        //{
        //    if (!ModelState.IsValid)
        //        return View(email);

        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user == null)
        //        return RedirectToAction(nameof(ForgotPasswordConfirmation));

        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

        //    EmailHelper emailHelper = new EmailHelper();
        //    bool emailResponse = emailHelper.SendEmailPasswordReset(user.Email, link);

        //    if (emailResponse)
        //        return RedirectToAction("ForgotPasswordConfirmation");
        //    else
        //    {
        //        // log email failed 
        //    }
        //    return View(email);
        //}


        //public IActionResult ForgotPasswordConfirmation()
        //{
        //    return View();
        //}


        //public IActionResult ResetPassword(string token, string email)
        //{
        //    var model = new ResetPassword { Token = token, Email = email };
        //    return View(model);
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        //{
        //    if (!ModelState.IsValid)
        //        return View(resetPassword);

        //    var user = await _userManager.FindByEmailAsync(resetPassword.Email);
        //    if (user == null)
        //        RedirectToAction("ResetPasswordConfirmation");

        //    var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
        //    if (!resetPassResult.Succeeded)
        //    {
        //        foreach (var error in resetPassResult.Errors)
        //            ModelState.AddModelError(error.Code, error.Description);
        //        return View();
        //    }

        //    return RedirectToAction("ResetPasswordConfirmation");
        //}

        //public IActionResult ResetPasswordConfirmation()
        //{
        //    return View();
        //}
    }
}
