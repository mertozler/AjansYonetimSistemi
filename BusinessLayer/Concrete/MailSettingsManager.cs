using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MailSettingsManager:IMailSettingsService
    {
        private IMailSettingsDal _mailSettingsDal;

        public MailSettingsManager(IMailSettingsDal mailSettingsDal)
        {
            _mailSettingsDal = mailSettingsDal;
        }

        public void Add(MailSettings t)
        {
            _mailSettingsDal.Insert(t);
        }

        public void Delete(MailSettings t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(MailSettings t)
        {
           _mailSettingsDal.Update(t);
        }

        public List<MailSettings> GetList()
        {
            return _mailSettingsDal.GetListAll();
        }

        public MailSettings GetById(int id)
        {
           return _mailSettingsDal.GetById(id);
        }
    }
}