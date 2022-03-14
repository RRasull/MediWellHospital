using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Dictionary<string, string> GetSetting();

    }
}
