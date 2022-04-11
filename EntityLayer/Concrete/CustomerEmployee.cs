using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class CustomerEmployee
    {
        [Key]
        public int ID { get; set; }

        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }
        public string EmployeeID { get; set; }
        public ApplicationUser Employee { get; set; }
        public bool Status { get; set; }
    }
}