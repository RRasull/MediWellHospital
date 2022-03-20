using Business.ViewModels.DepartmentVM;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IDepartmentService
    {
        Task<List<DepartmentGetVM>> GetAllAsync();
        Task<Departament> GetAsync(int id);
        Task CreateAsync(DepartmentCreateVM createVM);
        DepartmentUpdateVM Update(int id);
        Task UpdateAsync(int id, DepartmentUpdateVM updateVM);
        Task RemoveAsync(int id);
    }
}
