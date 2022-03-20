using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
    [Authorize(Roles = "Admin")]
    public class EmailAdminController : Controller
    {
        private UserManager<User> _userManager;
        public EmailAdminController(UserManager<User> usrMgr)
        {
            _userManager = usrMgr;
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
    }
}
