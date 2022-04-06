using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class CustomerServicePlanning
    {
        [Key] 
        public int ID { get; set; }

        public string PlannerID { get; set; }
        public ApplicationUser Planner { get; set; }
        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }
        public int ServiceID { get; set; }
        public Services Service { get; set; }
        public bool Status { get; set; }
    }
}