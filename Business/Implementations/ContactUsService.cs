using Business.Exceptions;
using Business.Interfaces;
using Business.ViewModels.ContactUsVM;
using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class ContactUsService : IContactUsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactUsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ContactUsViewModel>> GetAllAsync()
        {
            var dbContactUs = await _unitOfWork.contactUsRepository.GetAllAsync(d => !d.IsDeleted);


            List<ContactUsViewModel> contactUsVM = new List<ContactUsViewModel>();

            foreach (var contactUs in dbContactUs)
            {
                ContactUsViewModel readVM = new ContactUsViewModel
                {
                    Id = contactUs.Id,
                    Email = contactUs.Email,
                    Message = contactUs.Message,
                    Subject = contactUs.Subject,
                    Setting = _unitOfWork.settingRepository.GetSetting()
                };
                contactUsVM.Add(readVM);
            }
            return contactUsVM;
        }

        public Task<ContactUs> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var dbContactUs = await _unitOfWork.contactUsRepository.GetAsync(d => !d.IsDeleted && d.Id == id);


            if (dbContactUs is null) throw new NotFoundException("While Remove Doctor Not Found");


            dbContactUs.IsDeleted = true;

            await _unitOfWork.SaveAsync();
        }
    }
}
