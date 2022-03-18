using Business.Interfaces;
using Business.ViewModels.AppointmentVM;
using Business.ViewModels.CardVM;
using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
   public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AppointmentGetVM>> GetAllAsync()
        {
            var dbAppointment = await _unitOfWork.appointmentRepository.GetAllAsync(d => !d.IsDeleted);


            List<AppointmentGetVM> appointmentVM = new List<AppointmentGetVM>();

            foreach (var appointment in dbAppointment)
            {
                AppointmentGetVM readVM = new AppointmentGetVM
                {
                    Id = appointment.Id,
                    AppointDate = appointment.AppointDate,
                    Status = appointment.Status,
                    DoctorComment = appointment.DoctorComment,
                    DoctorId = appointment.DoctorId,
                    Doctor = appointment.Doctor,
                    PatientId = appointment.PatientId,
                    Patient = appointment.Patient
                };

                appointmentVM.Add(readVM);
            }
            return appointmentVM;
        }
    }
}
