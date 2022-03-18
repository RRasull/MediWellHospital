using Business.ViewModels;
using Business.ViewModels.ContactUsVM;
using Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ContactUsViewModel contactUsViewModel = new ContactUsViewModel
            {
                Setting = _unitOfWork.settingRepository.GetSetting()

            };
            return View(contactUsViewModel);
        }


        public  IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ContactUsViewModel contactUsVM)
        {
            if (!ModelState.IsValid) return View(contactUsVM);


            return RedirectToAction(nameof(Index));

        }
    }
}
