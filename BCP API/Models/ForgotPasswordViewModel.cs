using System.ComponentModel.DataAnnotations;

namespace BCP_API.Models
{
    public class ForgotPasswordViewModel
    {

        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmpID { get; set; }
        [Required(ErrorMessage = "Old password is required.")]
        public string? OldPassword { get; set; }
        [Required(ErrorMessage = "New password is required.")]
        public string? NewPassword { get; set; }


    }
}
