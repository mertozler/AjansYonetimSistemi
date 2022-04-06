using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.DTOs
{
    public class DemandToEmployeeDTO
    {
        public List<ApplicationUser> EmployeeList { get; set; }
        [Required(ErrorMessage ="Başlık boş geçilemez.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="Başlık")]
        public string Title { get; set; }
        public string CreatorID { get; set; }
        [Required(ErrorMessage ="Personel seçimi boş geçilemez.")]
        public string ReceiverID { get; set; }
        [Required(ErrorMessage ="İçerik boş geçilemez.")]
        [StringLength(5000, MinimumLength = 3, ErrorMessage = "İçerik 3 ile 50 karakter arasında olmak zorundadır.")]
        [Display(Prompt ="İçerik")]
        public string Content { get; set; }
        public List<IFormFile> DemandFiles { get; set; }
        public List<DemandList> DemandList { get; set; }
        public List<ComingDemantToMe> DemandListInbox { get; set; }
    }

    public class DemandToEmployeeDTOList
    {
        public List<ApplicationUser> EmployeeList { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<IFormFile> DemandFiles { get; set; }
    }
    
    public class ComingDemantToMe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public bool Status { get; set; }
        public int? productId { get; set; }
    }

    public class DemandList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ReceiverName { get; set; }
        public bool Status { get; set; }
    }
}