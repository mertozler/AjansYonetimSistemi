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
        
        public int PeakcellSMSSettingsID { get; set; }
        
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
                [StringLength(100, MinimumLength = 1, ErrorMessage = "Şifre 1 ile 100 karkater arasında olmak zorundadır.")]
                [DataType(DataType.Password)]
                [Display(Prompt = "Şifrenizi Giriniz")]
                public string PeakcellPassword { get; set; }
                
                [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
                        [StringLength(100, MinimumLength = 1, ErrorMessage = "Kullanıcı 1 ile 100 karkater arasında olmak zorundadır.")]
                        [Display(Prompt = "Kullanıcı adınızı Giriniz")]
                        public string PeakcellUserName { get; set; }
                        [Required(ErrorMessage = "Başlık adı boş geçilemez.")]
                        [StringLength(100, MinimumLength = 1, ErrorMessage = "Başlık 1 ile 100 karkater arasında olmak zorundadır.")]
                        [Display(Prompt = "Başlık adınızı Giriniz")]
                        public string PeakcellHeader { get; set; }
                        
                        public int DigicellSMSSettingsID { get; set; }
        
                        [Required(ErrorMessage = "Şifre boş geçilemez.")]
                        [StringLength(100, MinimumLength = 1, ErrorMessage = "Şifre 1 ile 100 karkater arasında olmak zorundadır.")]
                        [DataType(DataType.Password)]
                        [Display(Prompt = "Şifrenizi Giriniz")]
                        public string DigicellPassword { get; set; }
                
                        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
                        [StringLength(100, MinimumLength = 1, ErrorMessage = "Kullanıcı 1 ile 100 karkater arasında olmak zorundadır.")]
                        [Display(Prompt = "Kullanıcı adınızı Giriniz")]
                        public string DigicellUserName { get; set; }
                        [Required(ErrorMessage = "Başlık adı boş geçilemez.")]
                        [StringLength(100, MinimumLength = 1, ErrorMessage = "Başlık 1 ile 100 karkater arasında olmak zorundadır.")]
                        [Display(Prompt = "Başlık adınızı Giriniz")]
                        public string DigicellHeader { get; set; }
                        
                        
                        public bool DigicellIsActive { get; set; }
                        
                        public bool ShouldCustomerBeAbleTooSeePaymentHistoryIsActive { get; set; }
                        public bool ShouldCustomerBeAbleTooSeeRelevantPersonelIsActive { get; set; }
    }
    
 
    
}