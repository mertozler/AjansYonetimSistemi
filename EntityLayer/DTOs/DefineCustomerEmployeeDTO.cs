using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs
{
    public class DefineCustomerEmployeeDTO
    {
        public string CustomerName { get; set; }
        public string SelectedCustomerID { get; set; }
        [Required(ErrorMessage ="Personel seçimi boş geçilemez.")]
        public string SelectedEmployeeID { get; set; }
        public List<EmployeeListDefineEmployee> EmployeeList { get; set; }
        public List<RoleListDefineEmployee> RoleList { get; set; }
    }

    public class EmployeeListDefineEmployee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        
    }
    public class RoleListDefineEmployee
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        
    }
}