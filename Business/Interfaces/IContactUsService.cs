using Business.ViewModels.ContactUsVM;
using System.Collections.Generic;
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
