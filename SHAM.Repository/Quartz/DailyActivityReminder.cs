using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Net;
using System.Net.Mail;
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
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _employeeRepository = scope.ServiceProvider.GetService<IEmployeeRepository>();
                    var _activityRepository = scope.ServiceProvider.GetService<IActivityRepository>();
                    var _PublicHolidays = scope.ServiceProvider.GetService<IPublicHolidays>();
                    var date = DateTime.Now;
                    var holidaySummary = _PublicHolidays.IsPublicHoliday(date);
                    if (holidaySummary != null || (date.DayOfWeek != DayOfWeek.Saturday) || (date.DayOfWeek != DayOfWeek.Sunday))
                    {
                        var notEntryEmployees = _employeeRepository.EntryDailyActivity();

                        foreach (var item in notEntryEmployees)
                        {

                            try
                            {
                                using (var mail = new MailMessage())
                                {
                                    mail.From = new MailAddress("noreply@gmail.com");
                                    mail.Subject = "SHAM - Aktivite Girişi Hatırlatma";
                                    mail.Body = EmailContents.ReminderDailyActivity(item.NAME, item.SURNAME);
                                    mail.IsBodyHtml = true;
                                    mail.To.Add(new MailAddress(item.MAIL));


                                    var client = new SmtpClient()
                                    {
                                        Port = 587,
                                        DeliveryMethod = SmtpDeliveryMethod.Network,
                                        UseDefaultCredentials = true,
                                        Host = "smtp.gmail.com",
                                        EnableSsl = true,
                                        Credentials = new NetworkCredential("yhesap00@gmail.com", "811201hs"),
                                    };
                                    client.Send(mail);

                                }
                            }
                            catch(Exception e)
                            {
                                //Logging
                                Console.WriteLine(e);
                            }
                            //_logger.LogInformation(item.MAIL);
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return Task.CompletedTask;
        }
    }
}