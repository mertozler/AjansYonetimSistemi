using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DigicellSMSSettings
    {
        [Key] 
        public int ID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Header { get; set; }
        public bool isActive { get; set; }
    }
}