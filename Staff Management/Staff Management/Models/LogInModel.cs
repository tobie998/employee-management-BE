using System.ComponentModel.DataAnnotations;

namespace StaffManage.Models
{
    public class LogInModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
