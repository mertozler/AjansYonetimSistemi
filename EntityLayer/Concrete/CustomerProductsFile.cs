using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class CustomerProductsFile
    {
        [Key] 
        public int ID { get; set; }

        public int CustomerProductsID { get; set; }
        public CustomerProducts CustomerProduct { get; set; }
        public string FilePath { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}