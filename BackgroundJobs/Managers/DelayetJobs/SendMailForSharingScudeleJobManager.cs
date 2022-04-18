using System.Threading.Tasks;
using BusinessLayer.Utils;

namespace BackgroundJobs.Managers.DelayetJobs
{
    public class SendMailForSharingScudeleJobManager
    {
        //send mail before sharing time selected employee
        public async Task Process(string employeeMail, string productTitle)
        {
            MailService mailService = new MailService();
            string mailContext =
                "Merhabalar, ilgilendiğiniz firmaya ait " + productTitle + " ürününüzün paylaşımına 3 saat kaldı. Lütfen kontrollerinizi yapınız";
            mailService.SendMailWithReceiverMailContextAndSubject(employeeMail, mailContext, productTitle + " Başlıklı Ürünün Paylaşımına 3 Saat Kaldı!");
            
        }
    }
}