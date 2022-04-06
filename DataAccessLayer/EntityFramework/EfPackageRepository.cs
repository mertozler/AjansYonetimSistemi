using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfPackageRepository: GenericRepository<Package>, IPackageDal
    {
        
    }
}