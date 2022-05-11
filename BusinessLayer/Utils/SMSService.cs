using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Utils
{
    public class SMSService
    {
        private DigicellSMSService _digicellSmsService = new DigicellSMSService();
        PeakcellSMSService _peakcellSmsService = new PeakcellSMSService();
        private DigicellSMSSettingsManager _digicellSmsSettingsManager =
            new DigicellSMSSettingsManager(new EfDigicellSMSSettingsRepository());
        PeakcellSMSSettingsManager _peakcellSmsSettingsManager = new PeakcellSMSSettingsManager(new EfPeakcellSMSSettingsRepository());
        
        public void SendSMS(string phoneNumber, string message)
        {
            var digicellSettings = _digicellSmsSettingsManager.GetSettings();
            var peakcellSettings = _peakcellSmsSettingsManager.GetSettings();
            var credit = _digicellSmsService.GetCredit().Split(" ")[1];
            int creditCount = Convert.ToInt32(credit);
            if (creditCount > 0)
            {
                if(digicellSettings.isActive==true)
                {
                    var response = _digicellSmsService.SendSMS(_digicellSmsService.NumberParams(phoneNumber, message));
                }
                
            }
            else
            {
                if (peakcellSettings.isActive == true)
                {
                    _peakcellSmsService.SendSMS(phoneNumber,message);
                }
            }
        }
    }
}