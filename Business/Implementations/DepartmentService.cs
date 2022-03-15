using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.ViewModels.DepartmentVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(DepartmentCreateVM createVM)
        {
            var dbDepartment = await _unitOfWork.departmentRepository.GetAllAsync(d => d.IsDeleted == false); 

                Departament department = new Departament
                {
                    Name = createVM.Name,
                    Photo = createVM.Photo

                };

            await _unitOfWork.departmentRepository.CreateAsync(department);
            await _unitOfWork.SaveAsync();

        }

       

        public async Task<List<Departament>> GetAllAsync()
        {
            return (await _unitOfWork.departmentRepository.GetAllAsync(d => !d.IsDeleted));
        }

        public Task<Departament> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public Departament Get(int id)
        //{
            
        //}

        

        public DepartmentUpdateVM Update(int id)
        {
            var dbDepartment = _unitOfWork.doctorRepository.Get(d => !d.IsDeleted && d.Id == id);

            if (dbDepartment is null) throw new NotFoundException("Department Not Found");

            DepartmentUpdateVM departmentupdateVM = new DepartmentUpdateVM
            {
                Name = dbDepartment.Name,
                Image = dbDepartment.Image,
                Photo = dbDepartment.Photo

            };

            return departmentupdateVM;

        }

        public async Task UpdateAsync(int id, DepartmentUpdateVM updateVM)
        {
            var dbDepartment = await _unitOfWork.departmentRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            DepartmentUpdateVM departmentupdateVM = new DepartmentUpdateVM
            {
                Id = dbDepartment.Id,
                Name = dbDepartment.Name,
                Image = dbDepartment.Image,
                Photo = dbDepartment.Photo

            };

            await _unitOfWork.SaveAsync();

        }

        public async Task RemoveAsync(int id)
        {
            var dbDepartment = _unitOfWork.doctorRepository.Get(d => !d.IsDeleted && d.Id == id);

            if (dbDepartment is null) throw new NotFoundException("While Remove Department Not Found");

            dbDepartment.IsDeleted = true;

            await _unitOfWork.SaveAsync();

        }
    }
}
