using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class MailSettingsDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Mail boş geçilemez.")]
        [Display(Prompt = "Mail Adresinizi Giriniz")]
        public string Mail { get; set; } 
        
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Şifre 1 ile 100 karkater arasında olmak zorundadır.")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Şifrenizi Giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage ="SMTP Server boş geçilemez.")]
        [Display(Prompt = "SMTP Server Adresini Giriniz")]
        public string SmtpServer { get; set; }
        [Required(ErrorMessage ="Port boş geçilemez.")]
        [Display(Prompt = "Port Numarasını Giriniz")]
        public int Port { get; set; }
    }
}