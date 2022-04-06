using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CustomerProdutcsManager:ICustomerProdutcsService
    {
        private ICustomerProdutcsDal _customerProdutcsDal;

        public CustomerProdutcsManager(ICustomerProdutcsDal customerProdutcsDal)
        {
            _customerProdutcsDal = customerProdutcsDal;
        }

        public void Add(CustomerProducts t)
        {
            _customerProdutcsDal.Insert(t);
        }

        public void Delete(CustomerProducts t)
        {
            _customerProdutcsDal.Delete(t);
        }

        public void Update(CustomerProducts t)
        {
            _customerProdutcsDal.Update(t);
        }

        public List<CustomerProducts> GetList()
        {
            throw new System.NotImplementedException();
        }
        
        public List<CustomerProducts> GetCustomerProductsListByCustomerID(string CustomerID)
        {
            return _customerProdutcsDal.GetListAll(x => x.CustomerID == CustomerID);
        }

        public CustomerProducts GetById(int id)
        {
            return _customerProdutcsDal.GetById(id);
        }
    }
}