using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SettingsManager:ISettingsService
    {
        private ISettingsDal _settingsDal;

        public SettingsManager(ISettingsDal settingsDal)
        {
            _settingsDal = settingsDal;
        }

        public void Add(Settings t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Settings t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Settings t)
        {
            _settingsDal.Update(t);
        }

        public List<Settings> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Settings GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Settings GetBySettingField(string field)
        {
            return _settingsDal.GetListAll(x => x.SettingField == field).FirstOrDefault();
        }
    }
}