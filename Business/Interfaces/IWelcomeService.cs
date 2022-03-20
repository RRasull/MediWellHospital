using Business.ViewModels.WelcomeVM;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IWelcomeService
    {
        Task<List<Welcome>> GetAllAsync();
        Task<Welcome> GetAsync(int id);
        Task CreateAsync(WelcomeCreateVM createVM);
        WelcomeUpdateVM Update(int id);
        Task UpdateAsync(int id, WelcomeUpdateVM updateVM);
        Task RemoveAsync(int id);

    }
}
