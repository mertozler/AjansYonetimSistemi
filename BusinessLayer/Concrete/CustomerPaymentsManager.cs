using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CustomerPaymentsManager:ICustomerPaymentsService
    {
        private ICustomerPaymentsDal _customerPaymentsDal;

        public CustomerPaymentsManager(ICustomerPaymentsDal customerPaymentsDal)
        {
            _customerPaymentsDal = customerPaymentsDal;
        }

        public void Add(CustomerPayment t)
        {
            _customerPaymentsDal.Insert(t);
        }

        public void Delete(CustomerPayment t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CustomerPayment t)
        {
            throw new System.NotImplementedException();
        }

        public List<CustomerPayment> GetList()
        {
            return _customerPaymentsDal.GetListAll();
        }
        public List<CustomerPayment> GetPaymentListByCustomerID(string CustomerID)
        {
            return _customerPaymentsDal.GetListAll(x => x.CustomerID == CustomerID);
        }

        public CustomerPayment GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}