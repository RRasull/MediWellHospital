using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels.Auth
{
   public class ForgetPasswordVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
