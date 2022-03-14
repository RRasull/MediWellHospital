﻿using AutoMapper;
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

namespace Business.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;



        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }
        public async Task CreateAsync(DoctorCreateVM createVM)
        {
            string fileName = await createVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Doctors");
            Doctor doctor = _mapper.Map<Doctor>(createVM);

            doctor.Image = fileName;


            await _unitOfWork.doctorRepository.CreateAsync(doctor);
            await _unitOfWork.SaveAsync();
        }

        public DoctorUpdateVM Update(int id)
        {
            var dbDoctor = _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            if (dbDoctor is null) throw new NotFoundException("Doctor Not Found") ;

            return _mapper.Map<DoctorUpdateVM>(dbDoctor);
        }

        public async Task UpdateAsync(int id, DoctorUpdateVM updateVM)
        {
            var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);


            var oldPath = Path.Combine(_env.WebRootPath, "assets", "images", "Doctors", updateVM.Photo.FileName);


            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            string fileName = await updateVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Doctors");


            dbDoctor.Name = updateVM.Name;
            dbDoctor.Surname = updateVM.Surname;
            dbDoctor.WorkingHours = updateVM.WorkingHours;
            dbDoctor.Description = updateVM.Description;
            dbDoctor.Address = updateVM.Address;
            dbDoctor.Education = updateVM.Education;
            dbDoctor.EmailAddress = updateVM.EmailAddress;
            dbDoctor.Fees = updateVM.Fees;
            dbDoctor.Gender = updateVM.Gender;
            dbDoctor.Splztion = updateVM.Splztion;
            dbDoctor.Phone = updateVM.Phone;
            dbDoctor.Departament = updateVM.Departament;

            dbDoctor.Image = fileName;

            await _unitOfWork.SaveAsync();
        }


        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return (await _unitOfWork.doctorRepository.GetAllAsync(d => !d.IsDeleted));
        }

        public Task<Doctor> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var dbDoctor = await _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            if (dbDoctor is null) throw new NotFoundException("While Remove Doctor Not Found");


            dbDoctor.Photo.RemoveFileAsync(_env.WebRootPath, "assets/images/Doctors", dbDoctor.Image);

            dbDoctor.IsDeleted = true;

            await _unitOfWork.SaveAsync();
        }

        
    }
}
