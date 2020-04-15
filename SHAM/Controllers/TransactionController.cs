using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Contracts;

namespace SHAM.UI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public TransactionController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendMail()
        {
            var employees = _employeeRepository.GetSendEmailDto();
            return View(employees);
        }
        [HttpPost]
        public JsonResult SendMailAll(List<int> employeesId, bool isInput)
        {
            try
            {
                if (employeesId.Count == 0)
                    return Json(new { status = false, error = "Mail göndermek için seçim yapmalısınız.." });
                if (isInput == false)
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                        return Json(new { status = false, error = "Çalışanlar hafta sonu aktivite girişi yapmayabilir.." });
                var subject = "Aktivite Hatırlatma";
                _employeeRepository.SendMailAllEmployees(employeesId, subject, isInput);
                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = e });
            }
        }
        [HttpPost]
        public JsonResult SendSpecialMail(List<int> id, string subject, string header, string content)
        {
            try
            {
                if (id.Count == 0)
                    return Json(new { status = false, error = "Mail göndermek için seçim yapmalısınız.." });
                if (subject == null)
                    return Json(new { status = false, error = "E Mail konusu bos olamaz.." });
                if (header == null)
                    return Json(new { status = false, error = "Başlık boş olamaz.." });
                if (content == null)
                    return Json(new { status = false, error = "İçerik bos olamaz.." });

                _employeeRepository.SendSpecialMailEmployee(id, subject, header, content);
                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = e });
            }
        }
        [HttpPost]
        public JsonResult SendSpecialMailProject(int? projectId, string subject, string header, string content)
        {
            try
            {
                if (projectId == null)
                    return Json(new { status = false, error = "Müşteri seçimi yaparak, proje seçiniz.." });
                if (subject == null)
                    return Json(new { status = false, error = "E Mail konusu bos olamaz.." });
                if (header == null)
                    return Json(new { status = false, error = "Başlık boş olamaz.." });
                if (content == null)
                    return Json(new { status = false, error = "İçerik bos olamaz.." });

                _employeeRepository.SendMailProjectEmployee((int)projectId, subject, header, content);
                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = e });
            }
        }
        [HttpPost]
        public JsonResult SendMailCustomer(List<int> customerId , string subject, string header, string content)
        {
            try
            {
                if (customerId.Count() == 0)
                    return Json(new { status = false, error = "Müşteri seçimi yapmalısınız.." });
                if (subject == null)
                    return Json(new { status = false, error = "E Mail konusu bos olamaz.." });
                if (header == null)
                    return Json(new { status = false, error = "Başlık boş olamaz.." });
                if (content == null)
                    return Json(new { status = false, error = "İçerik bos olamaz.." });

                _employeeRepository.SendMailCustomer(customerId, subject, header, content);
                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = e });
            }
        }

    }
}