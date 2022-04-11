using System;
using System.Collections.Generic;
using EntityLayer.Concrete;

namespace EntityLayer.DTOs
{
    public class CustomerDefineServiceDTO
    {
        public string selectedCustomerID { get; set; }
        public DateTime DateRange {get; set; }
        public List<CustomerListClassForDefineService> CustomerList { get; set; }
        public List<CustomerDefinedServiceListClass> CustomerDefinedServiceList { get; set; }
        public List<Services> ServiceList { get; set; }
        public List<Package> PackageList { get; set; }
        public List<PaymentRoutineTypesClass>   PaymentRoutineTypesList { get; set; }
        public int SelectedPaymentRoutineTypeID { get; set; }
    }
    public class CustomerListClassForDefineService
    {
        public string CustomerID { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerName { get; set; }
    }

    public class CustomerDefinedServiceListClass
    {
        public string CustomerID { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerName { get; set; }
        public string ServiceNames {get; set;}
        public string PaymentRoutineTypeName { get; set; }
    }

    public class PaymentRoutineTypesClass
    {
        public int PaymentRoutineID { get; set; }
        public string PaymentRoutineName { get; set; }
    }
}