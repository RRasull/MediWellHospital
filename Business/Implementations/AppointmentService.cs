using Business.Interfaces;
using Business.ViewModels.AppointmentVM;
using Business.ViewModels.CardVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
   public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;


        public AppointmentService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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
                    PatientMessage = appointment.PatientMessage,
                    PatientPhone = appointment.PatientPhone,
                    PatientEmail = appointment.PatientEmail,
                    Doctor = await _unitOfWork.doctorRepository.GetAsync(d => d.IsDeleted == false && d.Id == appointment.DoctorId),
                    PatientUserName = appointment.PatientUsername
                };

                appointmentVM.Add(readVM);
            }
            return appointmentVM;
        }

        public async Task CreateAsync(AppointCreateVM createVM)
        {
            Appointment appointmentCreate = new Appointment
            {
                AppointDate = createVM.AppointDate,
                PatientMessage = createVM.Message,
                PatientPhone = createVM.Phone,
                DoctorId = createVM.DoctorId,
                PatientUsername = createVM.User.UserName,
                PatientEmail = createVM.User.Email
            };

            await _unitOfWork.appointmentRepository.CreateAsync(appointmentCreate);
            await _unitOfWork.SaveAsync();
        }

    }
}
