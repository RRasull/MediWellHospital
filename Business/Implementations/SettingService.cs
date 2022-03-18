using Business.Interfaces;
using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
   public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Dictionary<string, string> GetSetting()
        {
            return _unitOfWork.settingRepository.GetSetting();
        }
    }
}
