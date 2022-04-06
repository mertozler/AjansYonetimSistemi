using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServiceManager:IServicesService
    {
        private IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Add(Services t)
        {
            _serviceDal.Insert(t);
        }

        public void Delete(Services t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Services t)
        {
            _serviceDal.Update(t);
        }

        public List<Services> GetList()
        {
            return _serviceDal.GetListAll();
        }
        
        

        public Services GetById(int id)
        {
            return _serviceDal.GetById(id);
        }
    }
}