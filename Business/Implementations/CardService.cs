using Business.Exceptions;
using Business.Interfaces;
using Business.ViewModels.CardVM;
using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(CardCreateVM createVM)
        {
            Card card = new Card
            {
                Title = createVM.Title,
                Description = createVM.Description,
                Icon = createVM.Icon
            };

            await _unitOfWork.cardRepository.CreateAsync(card);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<CardGetVM>> GetAllAsync()
        {
            var dbCard = await _unitOfWork.cardRepository.GetAllAsync(d => !d.IsDeleted);


            List<CardGetVM> cardVM = new List<CardGetVM>();

            foreach (var card in dbCard)
            {
                CardGetVM readVM = new CardGetVM
                {
                    Id = card.Id,
                    Icon = card.Icon,
                    Description = card.Description,
                    Title = card.Title
                };

                cardVM.Add(readVM);
            }
            return cardVM;
        }

        public Task<Card> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var dbCard = await _unitOfWork.cardRepository.GetAsync(d => !d.IsDeleted && d.Id == id);


            if (dbCard is null) throw new NotFoundException("While Remove Doctor Not Found");



            dbCard.IsDeleted = true;

            await _unitOfWork.SaveAsync();
        }

        public CardUpdateVM Update(int id)
        {
            var dbCard = _unitOfWork.cardRepository.Get(d => !d.IsDeleted && d.Id == id);

            if (dbCard is null) throw new NotFoundException("Card Not Found");

            CardUpdateVM cardUpdateVM = new CardUpdateVM
            {
                Id = dbCard.Id,
                Description = dbCard.Description,
                Title = dbCard.Title,
                Icon = dbCard.Icon
            };
            return cardUpdateVM;
        }

        public async Task UpdateAsync(int id, CardUpdateVM updateVM)
        {
            var dbCard =await _unitOfWork.cardRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            dbCard.Icon = updateVM.Icon;
            dbCard.Title = updateVM.Title;
            dbCard.Description = updateVM.Description;

            await _unitOfWork.SaveAsync();
        }
    }
}
