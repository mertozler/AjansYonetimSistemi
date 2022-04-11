using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CustomerEmployeeManager:ICustomerEmployeeService
    {
        private ICustomerEmployeeDal _customerEmployeeDal;

        public CustomerEmployeeManager(ICustomerEmployeeDal customerEmployeeDal)
        {
            _customerEmployeeDal = customerEmployeeDal;
        }

        public void Add(CustomerEmployee t)
        {
            _customerEmployeeDal.Insert(t);
        }

        public void Delete(CustomerEmployee t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CustomerEmployee t)
        {
            _customerEmployeeDal.Update(t);
        }

        public List<CustomerEmployee> GetList()
        {
            return _customerEmployeeDal.GetListAll();
        }
        public List<CustomerEmployee> GetEmployeeListByCustomerID(string CustomerID)
        {
            return _customerEmployeeDal.GetListAll(x=> x.CustomerID == CustomerID && x.Status == true);
        }
        public List<CustomerEmployee> GetEmployeeListByEmployeeID(string EmployeeID)
        {
            return _customerEmployeeDal.GetListAll(x=> x.EmployeeID == EmployeeID && x.Status == true);
        }
        public CustomerEmployee GetById(int id)
        {
            return _customerEmployeeDal.GetById(id);
        }
    }
}