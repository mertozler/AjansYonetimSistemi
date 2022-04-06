using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class EditServiceDTO
    {
        [Required(ErrorMessage ="Hizmet ismi boş geçilemez.")]
        [DataType(DataType.Text,ErrorMessage = "Hizmet ismi karakterlerden oluşmak zorundadır.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Hizmet ismi 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="Hizmet İsmi")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması boş geçilemez.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Hizmet açıklaması 3 ile 100 karkater arasında olmak zorundadır.")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Hizmet Açıklaması")]
        public string ServiceDescription { get; set; }
        
        public int ServiceID {get; set; }
    }
}