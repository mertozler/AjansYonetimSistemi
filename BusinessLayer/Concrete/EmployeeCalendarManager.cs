using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class EmployeeCalendarManager:IEmployeeCalendarService
    {
        private IEmployeeCalendarDal _employeeCalendarDal;

        public EmployeeCalendarManager(IEmployeeCalendarDal employeeCalendarDal)
        {
            _employeeCalendarDal = employeeCalendarDal;
        }

        public void Add(EmployeeCalendar t)
        {
            _employeeCalendarDal.Insert(t);
        }

        public void Delete(EmployeeCalendar t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(EmployeeCalendar t)
        {
            _employeeCalendarDal.Update(t);
        }

        public List<EmployeeCalendar> GetList()
        {
            throw new System.NotImplementedException();
        }
        
        public List<EmployeeCalendar> GetListbyEmployeeID(string EmployeeID)
        {
            return _employeeCalendarDal.GetListAll(x => x.EmployeeID == EmployeeID);
        }

        public EmployeeCalendar GetById(int id)
        {
            return _employeeCalendarDal.GetById(id);
        }
    }
}