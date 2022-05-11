using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PeakcellSMSSettingsManager:IPeakcellSMSSettingsService
    {
        private IPeakcellSMSSettingsDal _peakcellSmsSettingsDal;

        public PeakcellSMSSettingsManager(IPeakcellSMSSettingsDal peakcellSmsSettingsDal)
        {
            _peakcellSmsSettingsDal = peakcellSmsSettingsDal;
        }

        public void Add(PeakcellSMSSettings t)
        {
            _peakcellSmsSettingsDal.Insert(t);
        }

        public void Delete(PeakcellSMSSettings t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(PeakcellSMSSettings t)
        {
            _peakcellSmsSettingsDal.Update(t);
        }

        public List<PeakcellSMSSettings> GetList()
        {
            throw new System.NotImplementedException();
        }

        public PeakcellSMSSettings GetById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public PeakcellSMSSettings GetSettings()
        {
            return _peakcellSmsSettingsDal.GetListAll().FirstOrDefault();
        }
    }
}