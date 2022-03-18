using Business.Interfaces;
using Business.ViewModels.AppointmentVM;
using Business.ViewModels.CardVM;
using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
   public class AppointmentService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CreateAsync(CardCreateVM createVM)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<CardGetVM>> GetAllAsync()
        //{
        //    var dbAppointment = await _unitOfWork.appointmentRepository.GetAllAsync(d => !d.IsDeleted);


        //    List<AppointmentGetVM> appointmentVM = new List<AppointmentGetVM>();

        //    foreach (var card in dbAppointment)
        //    {
        //        CardGetVM readVM = new CardGetVM
        //        {
        //            Id = card.Id,
        //            Icon = card.Icon,
        //            Description = card.Description,
        //            Title = card.Title
        //        };

        //        cardVM.Add(readVM);
        //    }
        //    return cardVM;
        //}

        public Task<Card> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public CardUpdateVM Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, CardUpdateVM updateVM)
        {
            throw new NotImplementedException();
        }
    }
}
