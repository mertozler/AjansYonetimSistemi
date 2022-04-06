using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.DTOs
{
    public class CustomerPlanningServiceForADayDTO
    {
        [Required(ErrorMessage ="Başlık boş geçilemez.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="Başlık")]
        public string title { get; set; }
        
        [Required(ErrorMessage ="Başlangıç tarihi boş geçilemez.")]
        [Display(Prompt ="Başlangıç tarihi")]
        public DateTime start { get; set; }
        
        [Required(ErrorMessage ="Bitiş tarihi boş geçilemez.")]
        [Display(Prompt ="Bitiş tarihi")]
        public DateTime end { get; set; }
        
        [Required(ErrorMessage ="İçerik boş geçilemez.")]
        [StringLength(5000, MinimumLength = 3, ErrorMessage = "İçerik 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="İçerik")]
        public string Content { get; set; }
        
        public string ProductType { get; set; }
        
        public string CustomerID {get; set; }
        [Display(Prompt ="Dosya yükle")]
        public List<IFormFile> CustomerProductFiles { get; set; }
        public int CustomerProductsID { get; set; }
        
    }
}