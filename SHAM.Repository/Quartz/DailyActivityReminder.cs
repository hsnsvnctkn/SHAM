using Microsoft.Extensions.Logging;
using Quartz;
using SHAM.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHAM.Repository.Quartz
{
    [DisallowConcurrentExecution]
    public class DailyActivityReminder : IJob
    {
        private readonly ILogger<DailyActivityReminder> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IEmployeeRepository _employeeRepository;

        public DailyActivityReminder(
            ILogger<DailyActivityReminder> logger,
            IEmailSender emailSender,
            IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _emailSender = emailSender;
            _employeeRepository = employeeRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var notEntryEmployees = _employeeRepository.EntryDailyActivity();

            foreach (var item in notEntryEmployees)
            {
                var body = "<p><b>Sayın,</b> " + item.NAME + " " + item.SURNAME + ";</p>" + 
                    "<p>Bugün girdiğiniz bir aktivite bulunmamaktadır.</p>" + 
                    "<p>Aktivitenizi girmek için lütfen tıklayınız.. </p>" +
                    "<p><a href=\"http://sham.sagita.com.tr\"> <input type=\"button\" value=\"Aktivite Giriş\" /></a> </p>";
                _emailSender.Send(item.MAIL, "SHAM - Aktivite Girişi Hatırlatma", body);

            }
            return Task.CompletedTask;
        }
    }
}
//   _logger.LogInformation("Hello world!");
