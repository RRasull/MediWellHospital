using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities.Helper;
using Business.ViewModels.PatientVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public PatientService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        public async Task CreateAsync(PatientCreateIdentityVM createIdentityVM)
        {

            string fileName = await createIdentityVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Patients");
            Patient patient = new Patient
            {
                Name = createIdentityVM.Name,
                Surname = createIdentityVM.Surname,
                Phone = createIdentityVM.Phone,
                Address = createIdentityVM.Address,
                BirthDate= createIdentityVM.BirthDate,
                Gender= createIdentityVM.Gender,
                EmailAddress = createIdentityVM.Email,
                Description = createIdentityVM.Description,
                Height = createIdentityVM.Height,
                Weight = createIdentityVM.Weight,
                Photo = createIdentityVM.Photo,
                
            };

            patient.Image = fileName;


            await _unitOfWork.patientRepository.CreateAsync(patient);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<PatientGetVM>> GetAllAsync()
        {
            var dbPatient = await _unitOfWork.patientRepository.GetAllAsync(d => !d.IsDeleted);


            List<PatientGetVM> doctorVM = new List<PatientGetVM>();

            foreach (var patient in dbPatient)
            {
                PatientGetVM readVM = new PatientGetVM
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    Surname = patient.Surname,
                    EmailAddress = patient.EmailAddress,
                    Address = patient.Address,
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Description = patient.Description,
                    Height = patient.Height,
                    Weight = patient.Weight,
                    Image = patient.Image,
                    Phone = patient.Phone
                };

                doctorVM.Add(readVM);
            }
            return doctorVM;
        }

        public async Task<Patient> GetAsync(int id)
        {
            return await _unitOfWork.patientRepository.GetAsync(d => d.IsDeleted == false && d.Id == id);

        }

        public async Task RemoveAsync(int id)
        {
            //var dbPatient = await _unitOfWork.patientRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            //var dbUser = await _unitOfWork.usersRepository.GetAsync(d => int.Parse(d.Id) == id);


            //if (dbPatient is null) throw new NotFoundException("While Remove Doctor Not Found");


            //dbPatient.Photo.RemoveFileAsync(_env.WebRootPath, "assets/images/Doctors", dbPatient.Image);

            //dbPatient.IsDeleted = true;
            //_unitOfWork.usersRepository.Remove(dbUser);

            //await _unitOfWork.SaveAsync();
        }

        public PatientUpdateVM Update(int id)
        {
            var dbPatient = _unitOfWork.patientRepository.Get(d => !d.IsDeleted && d.Id == id);

            if (dbPatient is null) throw new NotFoundException("Patient Not Found");

            PatientUpdateVM patientUpdateVM = new PatientUpdateVM
            {
                Id = dbPatient.Id,
                Name = dbPatient.Name,
                Surname = dbPatient.Surname,
                Gender = dbPatient.Gender,
                Address = dbPatient.Address,
                Description = dbPatient.Description,
                Phone = dbPatient.Phone,
                Photo = dbPatient.Photo,
                BirthDate = dbPatient.BirthDate,
                Email = dbPatient.EmailAddress,
                Height = dbPatient.Height,
                Weight = dbPatient.Weight,
                
            };
            return patientUpdateVM;
        }

        public async Task UpdateAsync(int id, PatientUpdateVM updateVM)
        {
            if (id != updateVM.Id) throw new BadRequestException("400 Bad Request");
            var dbPatient = await _unitOfWork.patientRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbPatient is null) throw new BadRequestException("404 Not Found");

            //var departaments = await _unitOfWork.departmentRepository.GetAllAsync();

            //PatientCreateIdentityVM doctorCreate = new PatientCreateIdentityVM
            //{
            //    Departaments = departaments
            //};

            if (updateVM.Photo != null)
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

                dbPatient.Image = fileName;

            }


            //dbDoctor.Name = updateVM.Name != null ? updateVM.Name : dbDoctor.Name;
            //dbDoctor.Surname = updateVM.Surname != null ? updateVM.Surname : dbDoctor.Surname;
            //dbDoctor.WorkingHours = updateVM.WorkingHours != null ? updateVM.WorkingHours : dbDoctor.WorkingHours;
            //dbDoctor.Description = updateVM.Description != null ? updateVM.Description : dbDoctor.Description;
            //dbDoctor.Address = updateVM.Address != null ? updateVM.Address : dbDoctor.Address;
            //dbDoctor.Education = updateVM.Education != null ? updateVM.Education : dbDoctor.Education;
            //dbDoctor.Fees = updateVM.Fees != null ? updateVM.Fees : dbDoctor.Fees;
            //dbDoctor.Gender = updateVM.Gender != null ? updateVM.Gender : dbDoctor.Gender;
            //dbDoctor.Phone = updateVM.Phone != null ? updateVM.Phone : dbDoctor.Phone;
            //dbDoctor.DepartamentId = updateVM.DepartamentId != null ? updateVM.DepartamentId : dbDoctor.DepartamentId;

            dbPatient.Name = dbPatient.Name != null ? dbPatient.Name : dbPatient.Name;
            dbPatient.Surname = dbPatient.Surname != null ? dbPatient.Surname : dbPatient.Surname;
            dbPatient.Address = dbPatient.Address != null ? dbPatient.Address : dbPatient.Address;
            dbPatient.BirthDate = dbPatient.BirthDate != null ? dbPatient.BirthDate : dbPatient.BirthDate;
            dbPatient.Description = dbPatient.Description != null ? dbPatient.Description : dbPatient.Description;
            dbPatient.Gender = dbPatient.Gender != null ? dbPatient.Gender : dbPatient.Gender;
            dbPatient.Weight = dbPatient.Weight != null ? dbPatient.Weight : dbPatient.Weight;
            dbPatient.Height = dbPatient.Height != null ? dbPatient.Height : dbPatient.Height;
            dbPatient.Phone = dbPatient.Phone != null ? dbPatient.Phone : dbPatient.Phone;



            await _unitOfWork.SaveAsync();
        }
    }
}
