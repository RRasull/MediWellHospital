using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface ISettingService
    {
        Task<List<Setting>> GetAllAsync();
    }
}
