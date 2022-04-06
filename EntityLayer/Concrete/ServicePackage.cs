using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class ServicePackage
    {
        [Key] 
        public int ID { get; set; }

        public int ServiceID { get; set; }
        public Services Service { get; set; }
        public int PackageID { get; set; }
        public Package Package { get; set; }
    }
}