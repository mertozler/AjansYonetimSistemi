using System.Net.Mail;
using System.Text;

namespace BusinessLayer.Utils
{
    public class MailService
    {
        public void SendMailWithReceiverMailContextAndSubject(string toMail, string mailContext, string mailSubject)
        {
            string to = toMail; //To address    
            string from = "companypanel@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            string mailbody = mailContext;
            message.Subject = mailSubject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("companypanel15@gmail.com", "123456Admin.");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
        }
    }
}