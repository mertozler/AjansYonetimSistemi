using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class CustomerServicePlanCreateDTO
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
        
        [Display(Prompt ="İçerik")]
        public string Content { get; set; }
        
        public string ProductType { get; set; }
        
        public string CustomerID {get; set; }

        [Required(ErrorMessage ="Hizmet seçimi boş geçilemez.")]
        
        public int SelectedServiceID { get; set; }
        
        public List<ServiceList> ServiceList { get; set; }
    }

    public class ServiceList
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
    }
}