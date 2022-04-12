using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class MailSettings
    {
        [Key]
        public int ID { get; set; }

        public string Mail { get; set; }
        public string Password { get; set; }
        public string SMTPServer { get; set; }
        public int Port { get; set; }
    }
}