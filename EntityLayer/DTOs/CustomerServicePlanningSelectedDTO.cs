using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class CustomerServicePlanningSelectedDTO
    {
        public List<CustomerListWithServiceName> customerList = new List<CustomerListWithServiceName>();
    }
    public class CustomerListWithServiceName
    {
        public string CustomerID { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerName { get; set; }
        public string ServiceNames {get; set;}
    }
}