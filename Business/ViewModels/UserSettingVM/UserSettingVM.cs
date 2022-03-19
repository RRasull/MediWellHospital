using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.UserSettingVM
{
   public class UserSettingVM
    {

        [MaxLength(255), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ MaxLength(255), DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [MaxLength(255), DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
        [MaxLength(255)]
        public string Username { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        public string Image { get; set; }

    }
}
