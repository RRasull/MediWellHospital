using Business.ViewModels.PatientVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IPatientService
    {
        Task<List<PatientGetVM>> GetAllAsync();
        Task<Patient> GetAsync(int id);
        Task CreateAsync(PatientCreateIdentityVM createIdentityVM);
        PatientUpdateVM Update(int id);
        Task UpdateAsync(int id, PatientUpdateVM updateVM);
        Task RemoveAsync(int id);
    }
}
