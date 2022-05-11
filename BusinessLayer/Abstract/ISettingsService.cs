using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISettingsService:IGenericService<Settings>
    {
        public Settings GetBySettingField(string field);
    }
}