using Business.ViewModels.AppointmentVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IAppointmentService
    {
        Task<List<AppointmentGetVM>> GetAllAsync();
        //Task<Doctor> GetAsync(int id);
        //Task CreateAsync(DoctorCreateIdentityVM createIdentityVM);
        //Task<DoctorUpdateVM> Update(int id);
        //Task UpdateAsync(int id, DoctorUpdateVM updateVM);
        //Task RemoveAsync(int id);
    }
}
