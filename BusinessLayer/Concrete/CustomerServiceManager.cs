using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CustomerServiceManager:ICustomerServiceService
    {
        private ICustomerServiceDal _customerServiceDal;

        public CustomerServiceManager(ICustomerServiceDal customerServiceDal)
        {
            _customerServiceDal = customerServiceDal;
        }

        public void Add(CustomerService t)
        {
            _customerServiceDal.Insert(t);
        }

        public void Delete(CustomerService t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CustomerService t)
        {
            throw new System.NotImplementedException();
        }

        public List<CustomerService> GetList()
        {
            return _customerServiceDal.GetListAll();
        }
        
        public List<CustomerService> GetCustomerServiceByServiceID(int id)
        {
            return _customerServiceDal.GetListAll(x=> x.ServiceID == id);
        }
        
        
        public List<CustomerService> GetCustomerServiceByCustomerID(string customerId)
        {
            return _customerServiceDal.GetListAll(x=> x.CustomerID == customerId);
        }

        public CustomerService GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}