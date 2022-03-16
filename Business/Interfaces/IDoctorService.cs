using Business.ViewModels.DoctorVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IDoctorService
    {
        Task<List<DoctorGetVM>> GetAllAsync();
        Task<Doctor> GetAsync(int id);
        Task CreateAsync(DoctorCreateIdentityVM createIdentityVM);
        DoctorUpdateVM Update(int id);
        Task UpdateAsync(int id, DoctorUpdateVM updateVM);
        Task RemoveAsync(int id);

    }
}
