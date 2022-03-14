using AutoMapper;
using Business.ViewModels.DoctorVM;
using Business.ViewModels.WelcomeVM;
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
            CreateMap<Doctor, DoctorCreateVM>().ReverseMap();
            CreateMap<Doctor, DoctorUpdateVM>().ReverseMap();
            CreateMap<Doctor, DoctorGetVM>().ReverseMap();





        }
    }
}
