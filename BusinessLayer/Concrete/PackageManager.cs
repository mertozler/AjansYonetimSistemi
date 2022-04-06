using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PackageManager:IPackageService
    {
        private IPackageDal _packageDal;

        public PackageManager(IPackageDal packageDal)
        {
            _packageDal = packageDal;
        }

        public void Add(Package t)
        {
            _packageDal.Insert(t);
        }

        public void Delete(Package t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Package t)
        {
            _packageDal.Update(t);
        }

        public List<Package> GetList()
        {
            return _packageDal.GetListAll();
        }

        public Package GetById(int id)
        {
            return _packageDal.GetById(id);
        }
    }
}