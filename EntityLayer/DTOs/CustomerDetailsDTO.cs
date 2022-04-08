using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.DTOs
{
    public class CustomerDetailsDTO
    {
        public List<CustomerProductsClass> CustomerProductsList { get; set; }
        public CustomerProductDemandForMarketing CustomerRevisedRequest { get; set; }
        
        public int ProductID { get; set; }
        public string DemandAnswer { get; set; }
        public bool DemandStatus { get; set; }
        public List<DemandAnswers> DemandAnswersList { get; set; }
        public IFormFile RevisedFile { get; set; }
        public List<DemandFileClass> DemandFileList { get; set; }
    }

    public class CustomerProductsClass
    {
        public int ProductID { get; set; }
        public string ProductsTitle { get; set; }
        public string ProductstContent { get; set; }
        public string ProductstCreatorName{ get; set; }
        public string ProductstReceiverCustomerName{ get; set; }
        public string ProductsFilePath{ get; set; }
        public DateTime ProductCreateTime { get; set; }
        
    }
    
    public class CustomerProductDemandForMarketing
    {
        public string CreatorName { get; set; }
        public string DemandTitle { get; set; }
        public string DemandContent { get; set; }
        public DateTime DemandDate { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }

    public class DemandAnswers
    {
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }
        public byte AnswerType { get; set; }
        public DateTime DemandAnswerDate { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
    
    public class DemandFileClass
    {
        public string FileName { get; set;  }
        public string FilePath { get; set; }
        public DateTime FileDate { get; set; }
    }
}