using Microsoft.Extensions.Logging;
using Quartz;
using SHAM.Repository.Contracts;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISendEmail _sendEmail;

        public DailyActivityReminder(
            ILogger<DailyActivityReminder> logger,
            IEmployeeRepository employeeRepository,
            ISendEmail sendEmail)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _sendEmail = sendEmail;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var notEntryEmployees = _employeeRepository.EntryDailyActivity();

            foreach (var item in notEntryEmployees)
            {
                var credentials = new NetworkCredential("yhesap00@gmail.com", "811201hs");

                var body = "<p><b>Sayın,</b> " + item.NAME + " " + item.SURNAME + ";</p>" +
                    "<p>Bugün girdiğiniz bir aktivite bulunmamaktadır.</p>" +
                    "<p>Aktivitenizi girmek için lütfen tıklayınız.. </p>" +
                    "<p><a href=\"http://sham.sagita.com.tr\"> <input type=\"button\" value=\"Aktivite Giriş\" /></a> </p>";

                var mail = new MailMessage()
                {
                    From = new MailAddress("noreply@sham.sagita.com.tr"),
                    Subject = "SHAM - Aktivite Girişi Hatırlatma",
                    Body = body
                };

                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(item.MAIL));

                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mail);
                //_logger.LogInformation(item.MAIL);
            }
            return Task.CompletedTask;
        }
    }
}
//   _logger.LogInformation("Hello world!");
