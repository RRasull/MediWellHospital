using Business.Exceptions;
using Business.Interfaces;
using Business.ViewModels;
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
        private readonly ISettingService _settingService;



        public ContactUsService(IUnitOfWork unitOfWork, ISettingService settingService)
        {
            _unitOfWork = unitOfWork;
            _settingService = settingService;
        }

        public async Task CreateAsync(ContactUsCreateVM createVM)
        {
            ContactUs contactUs = new ContactUs
            {
                Email = createVM.Email,
                Name = createVM.Name,
                Message = createVM.Message,
                Subject = createVM.Subject
            };


            await _unitOfWork.contactUsRepository.CreateAsync(contactUs);
            await _unitOfWork.SaveAsync();
        }

        //public async Task<ContactUsViewModel> GetAsync()
        //{
        //    ContactUs dbContactUs = await _unitOfWork.contactUsRepository.GetAsync(d => d.IsDeleted == false);

        //    ContactUsViewModel readVM = new ContactUsViewModel
        //    {
        //        Id = dbContactUs.Id,
        //        Email = dbContactUs.Email,
        //        Message = dbContactUs.Message,
        //        Subject = dbContactUs.Subject
        //    };
        //    return readVM;
        //}

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
                    Name = contactUs.Name,
                    Message = contactUs.Message,
                    Subject = contactUs.Subject,
                    Setting = _unitOfWork.settingRepository.GetSetting()
                };
                contactUsVM.Add(readVM);
            }
            return contactUsVM;
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
