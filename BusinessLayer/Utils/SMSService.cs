using System;

namespace BusinessLayer.Utils
{
    public class SMSService
    {
        private DigicellSMSService _digicellSmsService = new DigicellSMSService();
        PeakcellSMSService _peakcellSmsService = new PeakcellSMSService();
        
        public void SendSMS(string phoneNumber, string message)
        {
            var credit = _digicellSmsService.GetCredit().Split(" ")[1];
            int creditCount = Convert.ToInt32(credit);
            if (creditCount > 0)
            {
                var response = _digicellSmsService.SendSMS(_digicellSmsService.NumberParams(phoneNumber, message));
            }
            else
            {
                _peakcellSmsService.SendSMS(phoneNumber,message);
            }
        }
    }
}