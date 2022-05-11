using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}