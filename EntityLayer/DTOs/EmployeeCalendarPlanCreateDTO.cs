using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class EmployeeCalendarPlanCreateDTO
    {
        [Required(ErrorMessage = "Başlık boş geçilemez.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt = "Başlık")]
        public string title { get; set; }

        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        [Display(Prompt = "Açıklama")]
        public string description { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi boş geçilemez.")]
        [Display(Prompt = "Başlangıç tarihi")]
        public DateTime start { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi boş geçilemez.")]
        [Display(Prompt = "Bitiş tarihi")]
        public DateTime end { get; set; }

        public int EventID { get; set; }
        public string EmployeeID { get; set; }
        public int SelectedServiceID { get; set; }

    }
    

}