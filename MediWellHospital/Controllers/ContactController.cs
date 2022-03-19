using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.ContactUsVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly ISettingService _settingService;
        private readonly IUnitOfWork _unitOfWork;


       

        public ContactController( IContactUsService contactUsService, ISettingService settingService, IUnitOfWork unitOfWork)
        {

            _contactUsService = contactUsService;
            _settingService = settingService;
            _unitOfWork = unitOfWork;
        }
        //public async Task<IActionResult> Index()
        //{
        //    //ContactUsViewModel dbContactUs = await _contactUsService.Get();
        //    ////ContactUsViewModel contactUsView = new ContactUsViewModel
        //    ////{
        //    ////    Setting = _settingService.GetSetting()
        //    ////};
        //    //HomeVM homeVM = new HomeVM
        //    //{
        //    //    Setting = _settingService.GetSetting(),
        //    //    ContactUsVM = dbContactUs
        //    //};
        //    //return View(homeVM);
        //    var dbContactUs = await _contactUsService.GetAllAsync();

        //    ContactUsCreateVM contactUsCreateVM = new ContactUsCreateVM
        //    {
        //        Email = dbContactUs.E
        //    };

        //    return View();
        //}


        public  IActionResult Create()
        {
            var setting = _settingService.GetSetting();


            ContactUsCreateVM contactUsCreate = new ContactUsCreateVM
            {
                Setting = setting
            };

            return View(contactUsCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactUsCreateVM contactUsCreateVM)
        {
            try
            {
              
                if (!ModelState.IsValid) return View(contactUsCreateVM);

                await _contactUsService.CreateAsync(contactUsCreateVM);
               
                contactUsCreateVM.Setting = _settingService.GetSetting();
                return RedirectToAction("SentSuccessfully","Contact");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(contactUsCreateVM);
            }

        }

        public IActionResult SentSuccessfully()
        {
            return View();
        }
    }
}
