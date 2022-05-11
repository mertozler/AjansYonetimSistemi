using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class AnnouncementDTO
    {
        [Required(ErrorMessage ="Başlık boş geçilemez.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 50 karakter arasında olmak zorundadır.")]
        public string Header { get; set; }
        [Required(ErrorMessage ="İçerik boş geçilemez.")]
        [StringLength(50000, MinimumLength = 3, ErrorMessage = "İçerik 3 ile 50 karakter arasında olmak zorundadır.")]
        public string Content { get; set; }
    }
}