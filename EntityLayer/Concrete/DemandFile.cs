using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DemandFile
    {
        [Key] 
        public int ID { get; set; }
        public int DemandID { get; set; }
        public Demand Demand { get; set; }
        public string CreatorID { get; set; }
        public ApplicationUser Creator { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}