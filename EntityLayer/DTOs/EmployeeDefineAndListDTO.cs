using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class EmployeeDefineAndListDTO
    {
        [Required(ErrorMessage ="Çalışan ismi boş geçilemez.")]
        [DataType(DataType.Text,ErrorMessage = "Çalışan ismi karakterlerden oluşmak zorundadır.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Çalışan ismi 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="İsim Soyisim")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email boş geçilemez.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email 3 ile 100 karakater arasında olmak zorundadır.")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Telefon Numarası boş geçilemez.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Telefon Numarası 10 karakater arasında olmak zorundadır.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Prompt = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Şifre 3 ile 100 karkater arasında olmak zorundadır.")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Şifre")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Şifre 3 ile 100 karkater arasında olmak zorundadır.")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Rol boş geçilemez.")]
        [Display(Prompt = "Personel Rolü")]
        public string Role { get; set; }

        public string EmployeeID { get; set; }
        public List<EmployeeListClass> EmployeeList { get; set; }
        public List<RoleListClass> RoleList { get; set; }  
    }

    public class EmployeeListClass
    {
        public string EmployeeID { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeeRole { get; set; }
        public string EmployeeName { get; set; }
    }

    public class RoleListClass
    {
        public string RoleName { get; set; }
    }
}