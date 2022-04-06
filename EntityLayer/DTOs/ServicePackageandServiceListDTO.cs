using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityLayer.Concrete;

namespace EntityLayer.DTOs
{
    public class ServicePackageandServiceListDTO
    {
        
        [Display(Prompt ="Hizmet İsmi")]
        public string ServiceName { get; set; }
       
        [Display(Prompt = "Hizmet Açıklaması")]
        public string ServiceDescription { get; set; }
        
        //If this button equal to 1 then create service otherwise this button equal to 2 then create package
        public int selectedButtonId { get; set; }
        
        
        [Display(Prompt ="Paket İsmi")]
        public string PackageName { get; set; }
        
        [Display(Prompt = "Paket Açıklaması")]
        public string PackageDescription { get; set; }

        public int ServiceId { get; set; }
        public List<Services> ServiceList { get; set; }
        public List<ServiceListViewModel> ServiceListViewModel {get; set; }
    }
    
    public class ServiceListViewModel {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string ServicePackageName { get; set; }
    }
}