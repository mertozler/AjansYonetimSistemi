using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DemandManager:IDemandService
    {
        IDemandDal _demandDal;

        public DemandManager(IDemandDal demandDal)
        {
            _demandDal = demandDal;
        }

        public void Add(Demand t)
        {
            _demandDal.Insert(t);
        }

        public void Delete(Demand t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Demand t)
        {
            _demandDal.Update(t);
        }

        public List<Demand> GetList()
        {
            throw new System.NotImplementedException();
        }
        public List<Demand> GetByEmployeeId(string id)
        {
            return _demandDal.GetListAll(x => x.CreatorId == id);
        }
        public List<Demand> GetDemandInboxByReceiverId(string id)
        {
            return _demandDal.GetListAll(x => x.ReceiverId == id);
        }

        public Demand GetById(int id)
        {
            return _demandDal.GetListAll(x => x.ID == id).FirstOrDefault();
        }
        public Demand GetByProductID(int id)
        {
            return _demandDal.GetListAll(x => x.CustomerProductsID == id).FirstOrDefault();
        }
    }
}