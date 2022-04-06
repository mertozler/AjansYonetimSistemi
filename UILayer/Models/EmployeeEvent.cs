using System;

namespace Project.Models
{
    public class EmployeeEvent
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
    }
}