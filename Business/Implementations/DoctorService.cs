using AutoMapper;
using Business.Exceptions;
using Business.Utilities.Helper;
using Business.Interfaces;
using Business.ViewModels.DoctorVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using static Business.Utilities.Helper.Helper;
using System.Security.Policy;
using Business.Utilities.Email;

namespace Business.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<User> _userManager;



        public DoctorService(IUnitOfWork unitOfWork, IWebHostEnvironment env, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _userManager = userManager;
        }
        public async Task CreateAsync(DoctorCreateIdentityVM identityCreateVM)
        {
            string fileName = await identityCreateVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Doctors");
            Doctor doctor = new Doctor
            {
                Name = identityCreateVM.DoctorName,
                Surname = identityCreateVM.DoctorSurname,
                Address = identityCreateVM.DoctorAddress,
                EmailAddress = identityCreateVM.Email,
                Education = identityCreateVM.DoctorEducation,
                Fees = identityCreateVM.DoctorFees,
                Photo = identityCreateVM.Photo,
                Gender = identityCreateVM.Gender,
                WorkingHours = identityCreateVM.DoctorWorkingHours,
                Phone = identityCreateVM.DoctorPhone,
                Description = identityCreateVM.Description,
                DepartamentId = identityCreateVM.DepartamentId
            };

            doctor.Image = fileName;


            await _unitOfWork.doctorRepository.CreateAsync(doctor);
            await _unitOfWork.SaveAsync();
        }

        

        public async Task<DoctorUpdateVM> Update(int id)
        {
            var departaments = await _unitOfWork.departmentRepository.GetAllAsync();
           

            var dbDoctor = _unitOfWork.doctorRepository.Get(d => !d.IsDeleted && d.Id == id);

            if (dbDoctor is null) throw new NotFoundException("Doctor Not Found") ;

            DoctorUpdateVM doctorUpdateVM = new DoctorUpdateVM
            {
                Id = dbDoctor.Id,
                Name = dbDoctor.Name,
                Surname = dbDoctor.Surname,
                Education = dbDoctor.Education,
                Gender = dbDoctor.Gender,
                Fees = dbDoctor.Fees,
                Address = dbDoctor.Address,
                Description = dbDoctor.Description,
                Phone = dbDoctor.Phone,
                Photo = dbDoctor.Photo,
                WorkingHours = dbDoctor.WorkingHours,
                Image = dbDoctor.Image,
                AllDepartaments = departaments
            };
            return doctorUpdateVM;
        }

        public async Task UpdateAsync(int id, DoctorUpdateVM updateVM)
        {
            if (id != updateVM.Id) throw new BadRequestException("400 Bad Request");
            var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbDoctor is null) throw new BadRequestException("404 Not Found");

            var departaments = await _unitOfWork.departmentRepository.GetAllAsync();

            DoctorCreateIdentityVM doctorCreate = new DoctorCreateIdentityVM
            {
                Departaments = departaments
            };

            if(updateVM.Photo != null)
            {
                if (!updateVM.Photo.CheckContent("image/"))
                {
                    throw new FileTypeException("Fayl şəkil formatında olmalıdır");

                }

                if (!updateVM.Photo.CheckLength(2000))
                {
                    throw new FileTypeException("Fayl 2 mb-dan az olmamalıdır");
                }

                //var dbUser = await _unitOfWork.usersRepository.GetAsync(u => u.Id==updateVM.UserId);


                var oldPath = Path.Combine(_env.WebRootPath, "assets", "images", "Doctors", updateVM.Photo.FileName);


                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                string fileName = await updateVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Doctors");
            }


            dbDoctor.Name = updateVM.Name != null ? updateVM.Name : dbDoctor.Name;
            dbDoctor.Surname = updateVM.Surname != null ? updateVM.Surname : dbDoctor.Surname;
            dbDoctor.WorkingHours = updateVM.WorkingHours != null ? updateVM.WorkingHours : dbDoctor.WorkingHours;
            dbDoctor.Description = updateVM.Description != null ? updateVM.Description : dbDoctor.Description;
            dbDoctor.Address = updateVM.Address != null ? updateVM.Address : dbDoctor.Address;
            dbDoctor.Education = updateVM.Education != null ? updateVM.Education : dbDoctor.Education;
            dbDoctor.Fees = updateVM.Fees != null ? updateVM.Fees : dbDoctor.Fees;
            dbDoctor.Gender = updateVM.Gender != null ? updateVM.Gender : dbDoctor.Gender;
            dbDoctor.Phone = updateVM.Phone != null ? updateVM.Phone : dbDoctor.Phone;
            dbDoctor.DepartamentId = updateVM.DepartamentId != null ? updateVM.DepartamentId : dbDoctor.DepartamentId;
            
            await _unitOfWork.SaveAsync();
        }


        public async Task<List<DoctorGetVM>> GetAllAsync()
        {
            var dbDoctor= await _unitOfWork.doctorRepository.GetAllAsync(d => !d.IsDeleted);

            List<DoctorGetVM> doctorVM = new List<DoctorGetVM>();

            foreach (var doctor in dbDoctor)
            {
                var department =await _unitOfWork.departmentRepository.GetAsync(d => !d.IsDeleted && d.Id ==doctor.DepartamentId);
                DoctorGetVM readVM = new DoctorGetVM
                {
                   Id = doctor.Id,
                   Name = doctor.Name,
                   Surname = doctor.Surname,
                   Address = doctor.Address,
                   Description = doctor.Address,
                   Education = doctor.Education,
                   EmailAddress = doctor.EmailAddress,
                   Image = doctor.Image ,
                   Phone = doctor.Phone,
                   Gender = doctor.Gender,
                   Fees = doctor.Fees,
                   WorkingHours = doctor.WorkingHours,
                   Departament = department
                };

                doctorVM.Add(readVM);
            }
            return doctorVM;
        }

        public Task<Doctor> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            //var user = await _userManager.GetUserAsync(User);
            //User dbUser = await _userManager.FindByIdAsync(user.);

            //var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            

            //if (dbDoctor is null) throw new NotFoundException("While Remove Doctor Not Found");


            //dbDoctor.Photo.RemoveFileAsync(_env.WebRootPath, "assets/images/Doctors", dbDoctor.Image);

            //dbDoctor.IsDeleted = true;
            //_unitOfWork.usersRepository.Remove(dbUser);

            //await _unitOfWork.SaveAsync();
        }

        public async Task<DoctorCreateIdentityVM> Create()
        {
            var departaments = await _unitOfWork.departmentRepository.GetAllAsync();
            DoctorCreateIdentityVM createDto = new DoctorCreateIdentityVM
            {
                Departaments = departaments
            };
            return createDto;
        }
    }
}
