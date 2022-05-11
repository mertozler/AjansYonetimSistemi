using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager:IAnnouncementService
    {
        private IAnnocumentDal _annocumentDal;

        public AnnouncementManager(IAnnocumentDal annocumentDal)
        {
            _annocumentDal = annocumentDal;
        }

        public void Add(Announcement t)
        {
            _annocumentDal.Insert(t);
        }

        public void Delete(Announcement t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Announcement t)
        {
            throw new System.NotImplementedException();
        }

        public List<Announcement> GetList()
        {
            return _annocumentDal.GetListAll();
        }

        public Announcement GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}