using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CustomerProductsFileManager:ICustomerProductsFileService
    {
        private ICustomerProductsFileDal _customerProductsFileDal;

        public CustomerProductsFileManager(ICustomerProductsFileDal customerProductsFileDal)
        {
            _customerProductsFileDal = customerProductsFileDal;
        }

        public void Add(CustomerProductsFile t)
        {
            _customerProductsFileDal.Insert(t);
        }

        public void Delete(CustomerProductsFile t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CustomerProductsFile t)
        {
            throw new System.NotImplementedException();
        }

        public List<CustomerProductsFile> GetList()
        {
            throw new System.NotImplementedException();
        }

        public CustomerProductsFile GetById(int id)
        {
            throw new System.NotImplementedException();
        }
        public CustomerProductsFile GetByProductId(int productId)
        {
            var product = _customerProductsFileDal.GetListAll(x => x.CustomerProductsID == productId);
            if (product.Count != 0)
            {
                return product[0];
            }
            return null;
        }
    }
}