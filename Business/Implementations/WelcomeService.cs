using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.ViewModels.WelcomeVM;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{

    public class WelcomeService : IWelcomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;



        public WelcomeService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(WelcomeCreateVM createVM)
        {
            Welcome welcome = _mapper.Map<Welcome>(createVM);

            await _unitOfWork.welcomeRepository.CreateAsync(welcome);
            await _unitOfWork.SaveAsync();

        }

        public async Task<List<Welcome>> GetAllAsync()
        {

            return (await _unitOfWork.welcomeRepository.GetAllAsync(d => !d.IsDeleted));

        }

        public async Task<Welcome> GetAsync(int id)
        {

            var dbWelcome = await _unitOfWork.welcomeRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            if (dbWelcome is null) throw new NullReferenceException();
            return dbWelcome;
        }

        public async Task RemoveAsync(int id) 
        {
            var dbWelcome = await _unitOfWork.welcomeRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            dbWelcome.IsDeleted = true;

            await _unitOfWork.SaveAsync();

        }

        public WelcomeUpdateVM Update(int id)
        {
            var dbWelcome = _unitOfWork.doctorRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            if (dbWelcome is null) throw new NotFoundException("Doctor Not Found");

            return _mapper.Map<WelcomeUpdateVM>(dbWelcome);
        }

        public async Task UpdateAsync(int id, WelcomeUpdateVM updateVM)
        {

            var dbWelcome = await _unitOfWork.welcomeRepository.GetAsync(d => !d.IsDeleted && d.Id == id);

            dbWelcome.Title = updateVM.Title;
            dbWelcome.Content = updateVM.Content;
            dbWelcome.WhyUs = updateVM.WhyUs;

            await _unitOfWork.SaveAsync();
        }
    }
}
