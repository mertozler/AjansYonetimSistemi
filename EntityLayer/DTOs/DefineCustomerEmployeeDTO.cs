using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class DefineCustomerEmployeeDTO
    {
        public string CustomerName { get; set; }
        public string SelectedRoleID { get; set; }
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