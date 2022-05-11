using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Utils
{
    public class MailService
    {
        MailSettingsManager _mailSettingsManager = new MailSettingsManager(new EfMailSettingsRepository());
        public void SendMailWithReceiverMailContextAndSubject(string toMail, string mailContext, string mailSubject)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
            var getMailSettingsData = _mailSettingsManager.GetList().FirstOrDefault();
            string to = toMail; //To address    
            string from = getMailSettingsData.Mail; //From address    
            MailMessage message = new MailMessage(from, to);
            string mailbody = mailContext;
            message.Subject = mailSubject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(getMailSettingsData.SMTPServer, getMailSettingsData.Port); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential(getMailSettingsData.Mail, getMailSettingsData.Password);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
        }
        private bool RemoteServerCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            //Console.WriteLine(certificate);
            return true;
        }
    }
}