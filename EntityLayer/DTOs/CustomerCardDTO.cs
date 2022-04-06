using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class CustomerCardDTO
    {
        
        [Display(Prompt = "Müşteri ID")]
        public string CustomerID { get; set; }
        [Display(Prompt = "Müşteri Mail")]
        public string CustomerMail { get; set; }
        [Display(Prompt = "Müşteri İsim")]
        public string CustomerName { get; set; }
        public List<CustomerCardServiceListClass> CustomerDefinedServiceList { get; set; }
    }
    public class CustomerCardServiceListClass
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime ServiceStartDate {get; set;}
        public DateTime ServiceEndDate {get; set;}
    }
        
}