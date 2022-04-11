using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class CustomerPaymentsDTO
    {
       public List<CustomerListWithPaymentRoutineName> paymentRoutineList { get; set; }
    }
    public class CustomerListWithPaymentRoutineName
    {
        public string CustomerID { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerName { get; set; }
        public string ServiceNames {get; set;}
        public string PaymentRoutineName {get; set;}
    }
}