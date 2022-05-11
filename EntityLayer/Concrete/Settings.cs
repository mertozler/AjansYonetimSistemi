using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Settings
    {
        [Key] 
        public int ID { get; set; }

        public string SettingField { get; set; }
        public bool SettingIsActive { get; set; }
        public bool Status { get; set; }
    }
}