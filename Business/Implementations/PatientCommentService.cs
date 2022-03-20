using Business.Exceptions;
using Business.Interfaces;
using Business.Utilities.Helper;
using Business.ViewModels.PatientCommentVM;
using Business.ViewModels.PatientVM;
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
   public class PatientCommentService : IPatientCommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public PatientCommentService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task<List<PatientCommentGetVM>> GetAllAsync()
        {
            var dbpatientCmnts = await _unitOfWork.patientCommentRepository.GetAllAsync(d => !d.IsDeleted);

            List<PatientCommentGetVM> pcommentVM = new List<PatientCommentGetVM>();

            foreach (var comment in dbpatientCmnts)
            {
                PatientCommentGetVM readVM = new PatientCommentGetVM
                {
                    Id = comment.Id,
                    Image = comment.Image,
                    Comment = comment.Comment,
                    Fullname = comment.Fullname,
                    Profession = comment.Profession,

                };

                pcommentVM.Add(readVM);
            }
            return pcommentVM;
        }

        public async Task<PatientComment> GetAsync(int id)
        {
            return await _unitOfWork.patientCommentRepository.GetAsync(d => d.IsDeleted == false && d.Id == id);
        }

        public async Task CreateAsync(PatientCommentCreateVM createVM)
        {
            var dbPatientComment = _unitOfWork.patientCommentRepository.Get(d => !d.IsDeleted);

            if (!createVM.Photo.CheckContent("image/"))
            {
                throw new FileTypeException("Fayl şəkil formatında olmalıdır");
            }

            if (!createVM.Photo.CheckLength(2000))
            {
                throw new FileTypeException("Fayl 2mb-dan çox ola bilməz");
            }

            string fileName = await createVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Patients");
            PatientComment patientComment = new PatientComment
            {
                Fullname = createVM.Fullname,
                Photo = createVM.Photo,
                Comment = createVM.Comment,
                Profession = createVM.Profession

            };
            patientComment.Image = fileName;

            await _unitOfWork.patientCommentRepository.CreateAsync(patientComment);
            await _unitOfWork.SaveAsync();
        }

        public PatientCommentUpdateVM Update(int id)
        {

            var dbPatientComment = _unitOfWork.patientCommentRepository.Get(d => d.IsDeleted == false && d.Id == id);

            if (dbPatientComment is null) throw new NotFoundException("Comment Not Found");

            PatientCommentUpdateVM departmentupdateVM = new PatientCommentUpdateVM
            {
                Fullname = dbPatientComment.Fullname,
                Profession = dbPatientComment.Profession,
                Comment = dbPatientComment.Comment,
                Image = dbPatientComment.Image

            };

            return departmentupdateVM;
        }

        public async Task UpdateAsync(int id, PatientCommentUpdateVM updateVM)
        {
            if (id != updateVM.Id) throw new BadRequestException("400 Bad Request");
            var dbPatientComment = await _unitOfWork.patientCommentRepository.GetAsync(d => !d.IsDeleted && d.Id == id);
            if (dbPatientComment is null) throw new NotFoundException("404 Not Found");

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

                var oldPath = Path.Combine(_env.WebRootPath, "assets", "images", "Patients", updateVM.Photo.FileName);


                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                string fileName = await updateVM.Photo.SaveFileAsync(_env.WebRootPath, "assets/images/Patients");

                dbPatientComment.Image = fileName;
            }


            dbPatientComment.Fullname = updateVM.Fullname != null ? updateVM.Fullname : dbPatientComment.Fullname;
            dbPatientComment.Comment = updateVM.Comment != null ? updateVM.Comment : dbPatientComment.Comment;
            dbPatientComment.Profession = updateVM.Profession != null ? updateVM.Profession : dbPatientComment.Profession;


            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var dbPatientComment = await _unitOfWork.patientCommentRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            if (dbPatientComment is null) throw new NotFoundException("While Remove Comment Not Found");

            dbPatientComment.IsDeleted = true;

            await _unitOfWork.SaveAsync();
        }

       
    }
}
