using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DigicellSMSSettingsManager:IDigicellSMSSettingsService
    {
        private IDigicellSMSSettingsDal _digicellSmsSettingsDal;

        public DigicellSMSSettingsManager(IDigicellSMSSettingsDal digicellSmsSettingsDal)
        {
            _digicellSmsSettingsDal = digicellSmsSettingsDal;
        }

        public void Add(DigicellSMSSettings t)
        {
            _digicellSmsSettingsDal.Insert(t);
        }

        public void Delete(DigicellSMSSettings t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DigicellSMSSettings t)
        {
            _digicellSmsSettingsDal.Update(t);
        }

        public List<DigicellSMSSettings> GetList()
        {
            throw new System.NotImplementedException();
        }

        public DigicellSMSSettings GetById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public DigicellSMSSettings GetSettings()
        {
            return _digicellSmsSettingsDal.GetListAll().FirstOrDefault();
        }
    }
}