using Business.ViewModels.PatientCommentVM;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IPatientCommentService
    {
        Task<List<PatientCommentGetVM>> GetAllAsync();
        Task<PatientComment> GetAsync(int id);
        Task CreateAsync(PatientCommentCreateVM createVM);
        PatientCommentUpdateVM Update(int id);
        Task UpdateAsync(int id, PatientCommentUpdateVM updateVM);
        Task RemoveAsync(int id);
    }
}
