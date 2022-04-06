using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class CustomerPayment
    {
        [Key] 
        public int ID { get; set; }

        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }
        public double PaymentPrice { get; set; }
        public int PaymentRoutineTypeID { get; set; }
        public PaymentRoutineType PaymentRoutineType { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Status { get; set; }
    }
}