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
        private readonly IWebHostEnvironment _env;



        public WelcomeService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task CreateAsync(WelcomeCreateVM createVM)
        {
            //Welcome welcome = _mapper.Map<Welcome>(createVM);


            Welcome welcome = new Welcome
            {
                Content = createVM.Content,
                WhyUs = createVM.WhyUs,
                Title = createVM.Title
            };

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
            var dbWelcome = _unitOfWork.welcomeRepository.Get(d => !d.IsDeleted && d.Id == id);

            if (dbWelcome is null) throw new NotFoundException("Doctor Not Found");

            WelcomeUpdateVM welcomeUpdateVM = new WelcomeUpdateVM
            {
                Id = dbWelcome.Id,
                Content = dbWelcome.Content,
                Title = dbWelcome.Title,
                WhyUs = dbWelcome.WhyUs
            };
            return welcomeUpdateVM;
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
