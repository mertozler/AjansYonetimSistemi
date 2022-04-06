using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class CustomerServicePlanningDate
    {
        [Key] 
        public int ID { get; set; }

        public int CustomerServicePlanningID { get; set; }
        public CustomerServicePlanning CustomerServicePlanning { get; set; }
        public DateTime ServiceDate { get; set; }
        public bool Status { get; set; }
    }
}