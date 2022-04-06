using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class CustomerService
    {
        [Key] 
        public int ID { get; set; }

        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }
        public int ServiceID { get; set; }
        public Services Service { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}