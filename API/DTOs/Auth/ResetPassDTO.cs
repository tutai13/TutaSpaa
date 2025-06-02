using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Auth
{
    public class ResetPassDTO
    {
        public string? UserID { get; set;  }
        public string OldPassword { get; set; }
        public string NewPassword  { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
