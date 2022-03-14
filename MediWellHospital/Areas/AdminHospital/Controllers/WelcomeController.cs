using AutoMapper;
using Business.Interfaces;
using Business.ViewModels.WelcomeVM;
using Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]

    public class WelcomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        private readonly IWelcomeService _welcomeService;

        public WelcomeController(IUnitOfWork unitOfWork, IWebHostEnvironment env, IMapper mapper, IWelcomeService welcomeService)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _mapper = mapper;
            _welcomeService = welcomeService;
        }

        public async Task<IActionResult> Index()
        {
            var dbWelcome = await _unitOfWork.welcomeRepository.GetAllAsync(w => w.IsDeleted == false);

            return View(await _welcomeService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(WelcomeCreateVM createVM)
        {

            await _welcomeService.CreateAsync(createVM);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            WelcomeUpdateVM welcomeUpdateVM = _welcomeService.Update(id);
            return View(welcomeUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, WelcomeUpdateVM welcomeUpdateVM)
        {
            if (!ModelState.IsValid) return View(welcomeUpdateVM);
            if (id != welcomeUpdateVM.Id) return BadRequest();
            var dbWelcome = await _unitOfWork.welcomeRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbWelcome is null) return NotFound();


           
            await _welcomeService.UpdateAsync(id, welcomeUpdateVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            await _welcomeService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
