using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities.Helper;
using Business.ViewModels.DepartmentVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;


        public DepartmentService(IUnitOfWork unitOfWork,IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task CreateAsync(DepartmentCreateVM createVM)
        {
            var dbDepartments = await _unitOfWork.departmentRepository.GetAllAsync(d => d.IsDeleted == false);
            bool isExist = await _unitOfWork.departmentRepository.IsExistsAsync(d => d.Name.ToLower().Trim() == createVM.Name.ToLower().Trim());

            if (isExist)
            {
                throw new DepartmentNameAlreadyExistsException("Department Name Already Exist");
            }

            if (!createVM.Photo.CheckContent("image/"))
            {
                throw new FileTypeException("Fayl şəkil formatında olmalıdır");
            }

            if (!createVM.Photo.CheckLength(2000))
            {
                throw new FileTypeException("Fayl 2mb-dan çox ola bilməz");
            }

            string fileName = await createVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Departaments");
            Departament department = new Departament
                {
                    Name = createVM.Name,
                    Photo = createVM.Photo,
                    Description = createVM.Description
                };
            department.Image = fileName;

            await _unitOfWork.departmentRepository.CreateAsync(department);
            await _unitOfWork.SaveAsync();

        }

       

        public async Task<List<DepartmentGetVM>> GetAllAsync()
        {
            var dbDepartments = await _unitOfWork.departmentRepository.GetAllAsync(d => !d.IsDeleted);

            List<DepartmentGetVM> departmentVM = new List<DepartmentGetVM>();

            foreach (var category in dbDepartments)
            {
                DepartmentGetVM readVM = new DepartmentGetVM
                {
                    Id = category.Id,
                    Name = category.Name,
                    Image = category.Image
                };

                departmentVM.Add(readVM);
            }
            return departmentVM;
        }

        public async Task<Departament> GetAsync(int id)
        {
            return await _unitOfWork.departmentRepository.GetAsync(d => d.IsDeleted == false && d.Id == id);
        }


        public DepartmentUpdateVM Update(int id)
        {
            var dbDepartment = _unitOfWork.departmentRepository.Get(d => !d.IsDeleted && d.Id == id);
           
            if (dbDepartment is null) throw new NotFoundException("Department Not Found");

            DepartmentUpdateVM departmentupdateVM = new DepartmentUpdateVM
            {
                Name = dbDepartment.Name,
                Image = dbDepartment.Image,
                Description = dbDepartment.Description
            };

            return departmentupdateVM;

        }

        public async Task UpdateAsync(int id, DepartmentUpdateVM updateVM)
        {
            if (id != updateVM.Id) throw new BadRequestException("400 Bad Request");
            var dbDepartment = await _unitOfWork.departmentRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbDepartment is null) throw new NotFoundException("404 Not Found");

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

                var oldPath = Path.Combine(_env.WebRootPath, "assets", "images", "Departaments", updateVM.Photo.FileName);


                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                string fileName = await updateVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Departaments");

                dbDepartment.Image = fileName;
            }

            bool isExist =await _unitOfWork.departmentRepository.IsExistsAsync(d => d.Name.ToLower().Trim() == updateVM.Name.ToLower().Trim());

            if (isExist)
            {
                throw new DepartmentNameAlreadyExistsException("Department Name Already Exist");
            }

            dbDepartment.Name = updateVM.Name != null ? updateVM.Name : dbDepartment.Name;
            dbDepartment.Description = updateVM.Description != null ? updateVM.Description : dbDepartment.Description;
            
           
            await _unitOfWork.SaveAsync();

        }

        public async Task RemoveAsync(int id)
        {
            var dbDepartment = _unitOfWork.departmentRepository.Get(d => !d.IsDeleted && d.Id == id);

            if (dbDepartment is null) throw new NotFoundException("While Remove Department Not Found");

            dbDepartment.IsDeleted = true;

            await _unitOfWork.SaveAsync();

        }
    }
}
