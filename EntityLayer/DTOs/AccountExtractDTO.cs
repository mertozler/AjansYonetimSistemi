using System;
using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class AccountExtractDTO
    {
        public List<CustomerCardServiceListClassForCustomer> CustomerServiceList { get; set; }
        public List<CustomerEmployeeListClassForCustomer> CustomerEmployeeList { get; set; }
        public List<PaymentHistoryClassForCustomer> CustomerPaymentHistory { get; set; }
        public double PaymentPriceSum { get; set; }
        public bool ShouldCustomerBeAbleTooSeePaymentHistoryIsActive { get; set; }
        public bool ShouldCustomerBeAbleTooSeeRelevantPersonelIsActive { get; set; }
    
    }
    
    public class CustomerCardServiceListClassForCustomer
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime ServiceStartDate {get; set;}
        public DateTime ServiceEndDate {get; set;}
    }

    public class CustomerEmployeeListClassForCustomer
    {
        public int CustomerEmployeeID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
    }
    
    public class PaymentHistoryClassForCustomer
    {
        public double PaymentPrice { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}