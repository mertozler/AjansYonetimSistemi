using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Web.Script.Serialization;
using SmsApiNode;
using SmsApiNode.Operations;

namespace BusinessLayer.Utils
{
    public class PeakcellSMSService
    {

        public void SendSMS(string phoneNumber, string message)
        {
            long phoneNumberLong = Convert.ToInt64(phoneNumber);
            var messenger = new Messenger("smslogin.nac.com.tr","username", "password");
            
            var singleSmsRequest = new SendSingleSms();
            singleSmsRequest.Content = message;
            singleSmsRequest.Number = phoneNumberLong;
            singleSmsRequest.Sender = "EGEBARKOD";
            
            //Title boş gönderilirse otomatik olarak yyyy-MM-dd hh:mm:ss formatını alır
            singleSmsRequest.Title = "EGEBARKOD";
            
            //Ticari gönderimlerde İYS sorgusu için Commercial alanı true gönderilmelidir
            //singleSmsRequest.Commercial = true;
            
            //İleri tarihli gönderimlerde kullanılır Yıl - Ay - Gün - Saat - Dakika - Saniye
            //singleSmsRequest.SendingDate = new DateTime(2021, 06, 11, 10, 00, 00);
            
            
            var singleSmsResponse = messenger.SendSingleSms(singleSmsRequest);
            
            if (singleSmsResponse.Err == null)
            {
                Console.WriteLine("Paket Id : " + singleSmsResponse.PackageId);
            }
            else
            {
                Console.WriteLine(
                    "Durum Statu  : " + singleSmsResponse.Err.Status + "\n" +
                    "Durum Kodu   : " + singleSmsResponse.Err.Code + "\n" +
                    "Durum Mesajı : " + singleSmsResponse.Err.Message
                );
            }	
        }
    }
}