using AutoMapper;
using Business.ViewModels.DoctorVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Profiles
{
   public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Doctor, DoctorCreateUpdateVM>().ReverseMap();
        }
    }
}
