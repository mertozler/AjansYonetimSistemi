using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class UserProfileDTO
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirm { get; set; }
    }
}