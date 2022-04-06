using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class ApplicationUser:IdentityUser<string>
    {
        public string NameSurname { get; set; }
        public bool Status { get; set; }
    }
}