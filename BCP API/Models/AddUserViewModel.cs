using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BCP_API.Models
{
    public class AddUserViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmpID { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public string? Project { get; set; }
        public string? Group { get; set; }
        public string? Role { get; set; }
    }
}
