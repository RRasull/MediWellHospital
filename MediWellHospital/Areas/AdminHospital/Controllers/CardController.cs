using Business.Exceptions;
using Business.Interfaces;
using Business.ViewModels.CardVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediWellHospital.Areas.AdminHospital.Controllers
{
    [Area("AdminHospital")]
    [Authorize(Roles = "Admin")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _cardService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CardCreateVM cardCreateVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(cardCreateVM);

                await _cardService.CreateAsync(cardCreateVM);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }

        }

        public CardUpdateVM Update(int id)
        {
            return _cardService.Update(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id, CardUpdateVM updateVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(updateVM);
                if (id != updateVM.Id) return BadRequest();

                await _cardService.UpdateAsync(id, updateVM);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
        }


        public Task<Card> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cardService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
            

        }
    }
}
