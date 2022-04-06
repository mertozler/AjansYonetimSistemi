using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Demand
    {
        [Key] 
        public int ID { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int? CustomerProductsID { get; set; }
        public CustomerProducts CustomerProducts { get; set; }
    }
}