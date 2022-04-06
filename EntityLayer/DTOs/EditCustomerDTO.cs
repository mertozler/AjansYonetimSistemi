using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class EditCustomerDTO
    {
        [Required(ErrorMessage ="Çalışan ismi boş geçilemez.")]
        [DataType(DataType.Text,ErrorMessage = "Çalışan ismi karakterlerden oluşmak zorundadır.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Çalışan ismi 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="İsim Soyisim")]
        public string Name { get; set; }
        
        public string CustomerID { get; set; }
    }
}