using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class EmployeeCalendar
    {
        [Key] 
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public string EmployeeID { get; set; }
        public ApplicationUser Employee { get; set; }
        public string description { get; set; }
        public bool Status { get; set; }
    }
}