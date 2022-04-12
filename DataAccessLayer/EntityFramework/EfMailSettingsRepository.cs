using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfMailSettingsRepository: GenericRepository<MailSettings>, IMailSettingsDal
    {
        
    }
}