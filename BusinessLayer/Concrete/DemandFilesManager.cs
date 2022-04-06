using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DemandFilesManager:IDemandFilesService
    {
        IDemandFilesDal _demandFilesDal;

        public DemandFilesManager(IDemandFilesDal demandFilesDal)
        {
            _demandFilesDal = demandFilesDal;
        }

        public void Add(DemandFile t)
        {
            _demandFilesDal.Insert(t);
        }

        public void Delete(DemandFile t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DemandFile t)
        {
            throw new System.NotImplementedException();
        }

        public List<DemandFile> GetList()
        {
            throw new System.NotImplementedException();
        }
        public List<DemandFile> GetByDemandID(int id)
        {
            return _demandFilesDal.GetListAll(x => x.DemandID == id);
        }

        public DemandFile GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}