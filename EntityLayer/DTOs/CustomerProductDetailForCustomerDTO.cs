using System;
using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class CustomerProductDetailForCustomerDTO
    {
        public string EmployeeName { get; set; }
        public string ProductTitle {get; set;}
        public string ProductContent { get; set; }
        public string ProductFilePath { get; set; }
        public DateTime ProductDate { get; set; }
        public int CustomerProductsID { get; set; }
        
        public string CustomerRequestContent { get; set; }
        public CustomerProductDemand RevisedRequest { get; set; }
        public List<DemandAnswersForCustomer> DemandAnswerList { get; set; }
       
        public List<DemandFileClassForCustomer> DemandFileList { get; set; }
        public bool DemandStatus { get; set; }
        
    }

    public class CustomerProductDemand
    {
        public string CreatorName { get; set; }
        public string DemandTitle { get; set; }
        public string DemandContent { get; set; }
        public DateTime DemandDate { get; set; }
    }
    public class DemandAnswersForCustomer
    {
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }
        public byte AnswerType { get; set; }
        public DateTime DemandAnswerDate { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime FileDate { get; set; }
    }
    
    public class DemandFileClassForCustomer
    {
        public string FileName { get; set;  }
        public string FilePath { get; set; }
        public DateTime FileDate { get; set; }
    }
    
}