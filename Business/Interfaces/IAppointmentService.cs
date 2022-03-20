using Business.ViewModels.AppointmentVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IAppointmentService
    {
        Task<List<AppointmentGetVM>> GetAllAsync();
        Task CreateAsync(AppointCreateVM appointCreateVM);

    }
}
