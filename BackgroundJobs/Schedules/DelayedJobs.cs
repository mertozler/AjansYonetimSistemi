using System;
using BackgroundJobs.Managers.DelayetJobs;

namespace BackgroundJobs.Schedules
{
    public class DelayedJobs
    {
        [Obsolete]
        public static void SendMailForSharingScudele(string employeeMail, string productTitle, DateTime date, string phoneNumber)
        {
            Hangfire.BackgroundJob.Schedule<SendMailForSharingScudeleJobManager>(
                job => job.Process(employeeMail, productTitle, phoneNumber),
                date);
        }
    }
}