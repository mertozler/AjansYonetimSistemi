using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NotificationManager:INotificationService
    {
        private INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void Delete(Notification t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Notification t)
        {
            _notificationDal.Update(t);
        }

        public List<Notification> GetList()
        {
            throw new System.NotImplementedException();
        }

        public List<Notification> GetListByCurrentUserId(string currentUserId)
        {
            return _notificationDal.GetListAll(x=>x.ReceiverUserID == currentUserId && x.isReaded == false);
        }
        
        public List<Notification> GetListByCurrentUserIdAll(string currentUserId)
        {
            return _notificationDal.GetListAll(x=>x.ReceiverUserID == currentUserId);
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }
    }
}