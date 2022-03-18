using Business.ViewModels.ContactUsVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IContactUsService
    {
        Task<List<ContactUsViewModel>> GetAllAsync();
        //Task<ContactUsViewModel> GetAsync();
        Task CreateAsync(ContactUsCreateVM contactCreateVM);

        Task RemoveAsync(int id);
    }
}
