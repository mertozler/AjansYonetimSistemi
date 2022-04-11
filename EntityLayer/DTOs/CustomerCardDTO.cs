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
        public List<CustomerEmployeeListClass> CustomerEmployeeList { get; set; }
        public List<PaymentHistoryClassForAdmin> PaymentHistoryList { get; set; }
        public List<ReportListClass> ReportList { get; set; }
        public double PaymentPriceSum { get; set; }
    }
    public class ReportListClassForAdmin
    {
        public int DemandID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string ProductContent { get; set; }
        public int ProductID { get; set; }
        public DateTime ProductDate { get; set; }
        public string ReportName { get; set; }
        public string ReportPath { get; set; }
        public bool DemandStatus { get; set; }
    }
    public class CustomerCardServiceListClass
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime ServiceStartDate {get; set;}
        public DateTime ServiceEndDate {get; set;}
    }

    public class CustomerEmployeeListClass
    {
        public int CustomerEmployeeID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
    }
    
    public class PaymentHistoryClassForAdmin
    {
        public double PaymentPrice { get; set; }
        public DateTime PaymentDate { get; set; }
    }
        
}