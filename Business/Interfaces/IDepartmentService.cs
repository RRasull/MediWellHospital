using Business.ViewModels.DepartmentVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IDepartmentService
    {
        Task<List<Departament>> GetAllAsync();
        Task<Departament> GetAsync(int id);
        Task CreateAsync(DepartmentCreateVM createVM);
        DepartmentUpdateVM Update(int id);
        Task UpdateAsync(int id, DepartmentUpdateVM updateVM);
        Task RemoveAsync(int id);
    }
}
