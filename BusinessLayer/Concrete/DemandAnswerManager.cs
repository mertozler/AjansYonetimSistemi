using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DemandAnswerManager:IDemandAnswerService
    {
        private IDemandAnswersDal _demandAnswersDal;

        public DemandAnswerManager(IDemandAnswersDal demandAnswersDal)
        {
            _demandAnswersDal = demandAnswersDal;
        }

        public void Add(DemandAnswer t)
        {
            _demandAnswersDal.Insert(t);
        }

        public void Delete(DemandAnswer t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DemandAnswer t)
        {
            throw new System.NotImplementedException();
        }

        public List<DemandAnswer> GetList()
        {
            throw new System.NotImplementedException();
        }

        public DemandAnswer GetById(int id)
        {
            throw new System.NotImplementedException();
        }
        public List<DemandAnswer> GetByDemandId(int id)
        {
            return _demandAnswersDal.GetListAll(x => x.DemandID == id);
        }
    }
}