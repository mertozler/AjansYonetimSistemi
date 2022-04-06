using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class EmployeePerfonmanceScore
    {
        [Key] 
        public int ID { get; set; }

        public string EmployeeID { get; set; }
        public ApplicationUser Employee { get; set; }
        public double Score { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}