using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
    [Authorize(Roles = "Admin")]

    public class ContactUsController : Controller
    {

        private readonly IContactUsService _contactUsService;


        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contactUsService.GetAllAsync());
        }

        //public IActionResult Create()
        //{

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ContactUsCreateVM contactUsCreateVM)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return View(contactUsCreateVM);
        //        await _contactUsService.CreateAsync(contactUsCreateVM);
        //        return View(contactUsCreateVM);
        //    }
        //    catch (Exception ex)
        //    {

        //        ModelState.AddModelError(String.Empty, ex.Message.ToString());
        //        return View(contactUsCreateVM);
        //    }
            
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await _contactUsService.RemoveAsync(id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(String.Empty, ex.Message.ToString());
        //        return RedirectToAction(nameof(Index));
        //    }

        //}
    }
}
