using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Utils
{
    public class EmployeeList
    {
        private Context _context = new Context();
        private UserManager<ApplicationUser> _userManager;

        public EmployeeList(Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<EmployeeListClass>> GetAllEmployee()
        {
            List<EmployeeListClass> employeListViewModel = new List<EmployeeListClass>();
            var employeeList = await (from user in _context.Users
                join userRole in _context.UserRoles
                    on user.Id equals userRole.UserId
                join role in _context.Roles
                    on userRole.RoleId equals role.Id
                where((role.Name == "designer" || role.Name == "ops" || role.Name == "marketing") && user.Status == true)
                select user).ToListAsync();
            foreach (var item in employeeList)
            {
                var employeeRole = await _userManager.GetRolesAsync(item);
                employeListViewModel.Add(new EmployeeListClass { EmployeeMail = item.Email, EmployeeID=item.Id,EmployeeName = item.NameSurname, EmployeeRole = employeeRole[0].ToUpper()});
            }

            return employeListViewModel.ToList();
        }
    }
}