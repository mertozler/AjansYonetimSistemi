using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class CustomerProducts
    {
        [Key] 
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }
        public string CreatorID { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public int ServiceID { get; set; }
        public Services Service { get; set; }
        public string description { get; set; }  
        public int CustomerProductsTypeID { get; set; }
        public CustomerProductsType CustomerProductsType { get; set; }
        public bool Status { get; set; }
    }
}