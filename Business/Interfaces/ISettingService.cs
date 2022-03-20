using System.Collections.Generic;

namespace Business.Interfaces
{
   public interface ISettingService
    {

        Dictionary<string, string> GetSetting();

    }
}
