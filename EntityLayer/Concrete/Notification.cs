using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Header { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string ReceiverUserID { get; set; }
        public ApplicationUser ReceiverUser { get; set; }
        public DateTime Date { get; set; }
        public bool isReaded { get; set; }
    }
}