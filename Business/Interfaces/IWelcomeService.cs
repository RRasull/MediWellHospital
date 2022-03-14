using Business.ViewModels.WelcomeVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IWelcomeService
    {
        Task<IEnumerable<Welcome>> GetAllAsync();
        Task CreateAsync(WelcomeCreateVM createVM);
        WelcomeUpdateVM Update(int id);
        Task UpdateAsync(int id, WelcomeUpdateVM updateVM);
        Task RemoveAsync(int id);
    }
}
