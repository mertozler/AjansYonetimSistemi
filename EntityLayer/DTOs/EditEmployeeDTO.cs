using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class EditEmployeeDTO
    {
        [Required(ErrorMessage ="Çalışan ismi boş geçilemez.")]
        [DataType(DataType.Text,ErrorMessage = "Çalışan ismi karakterlerden oluşmak zorundadır.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Çalışan ismi 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="İsim Soyisim")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email boş geçilemez.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email 3 ile 100 karkater arasında olmak zorundadır.")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Rol boş geçilemez.")]
        [Display(Prompt = "Role")]
        public string Role { get; set; }
        
        [Required(ErrorMessage ="Id boş geçilemez.")]
        public string EmployeeID { get; set; }
    }
}