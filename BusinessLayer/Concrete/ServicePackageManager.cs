using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServicePackageManager:IServicePackageService
    {
        private IServicePackageDal _servicePackageDal;

        public ServicePackageManager(IServicePackageDal servicePackageDal)
        {
            _servicePackageDal = servicePackageDal;
        }

        public void Add(ServicePackage t)
        {
            _servicePackageDal.Insert(t);
        }

        public void Delete(ServicePackage t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ServicePackage t)
        {
            _servicePackageDal.Update(t);
        }

        public List<ServicePackage> GetList()
        {
            return _servicePackageDal.GetListAll();
        }
        
        public List<ServicePackage> GetServiceIDListByPackageId(int id)
        {
            return _servicePackageDal.GetListAll(x=> x.PackageID == id);
        }
        
        public List<ServicePackage> GetPackageIDListByServiceId(int id)
        {
            return _servicePackageDal.GetListAll(x=> x.ServiceID == id);
        }

        public ServicePackage GetById(int id)
        {
            return _servicePackageDal.GetById(id);
        }
    }
}