using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class CustomerCreateAndListDTO
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
        

        public string CustomerID { get; set; }
        public List<CustomerListClass> CustomerList { get; set; }
    }
    public class CustomerListClass
    {
        public string CustomerID { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerName { get; set; }
    }
}