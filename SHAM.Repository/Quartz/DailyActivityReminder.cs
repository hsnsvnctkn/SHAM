using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nager.Date;
using Quartz;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SHAM.Repository.Quartz
{
    [DisallowConcurrentExecution]
    public class DailyActivityReminder : IJob
    {
        private readonly ILogger<DailyActivityReminder> _logger;
        private readonly IServiceProvider _serviceProvider;

        public DailyActivityReminder(
            ILogger<DailyActivityReminder> logger,
            IServiceProvider serviceProvider,
            ISendEmail sendEmail)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            //using (var scope = _serviceProvider.CreateScope())
            //{
            //    var _employeeRepository = scope.ServiceProvider.GetService<EmployeeRepository>();
            //    if (!DateSystem.IsPublicHoliday(DateTime.Now, CountryCode.TR))
            //    {
            //        var notEntryEmployees = _employeeRepository.EntryDailyActivity();

            //        foreach (var item in notEntryEmployees)
            //        {

            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress("noreply@gmail.com");
                mail.Subject = "SHAM - Aktivite Girişi Hatırlatma";
                mail.Body = EmailContents.ReminderDailyActivity("Hasan", "Sevinçtekin");
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("hasan.sevinctekin@sagita.com.tr"));

                using (var client = new SmtpClient())
                {
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = true;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("yhesap00@gmail.com", "811201hs");
                    client.Send(mail);
                }

            }
            //_logger.LogInformation(item.MAIL);
            //        }
            //    }

            //}
            return Task.CompletedTask;
        }
    }
}
//   _logger.LogInformation("Hello world!");
