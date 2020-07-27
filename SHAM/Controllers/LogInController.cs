using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    public class LogInController : Controller
    {
        readonly ITokenProvider _tokenProvider;
        readonly IEmployeeRepository _employeeRepository;
        private readonly ISendEmail _sendEmail;

        public LogInController(ITokenProvider tokenProvider, IEmployeeRepository employeeRepository, ISendEmail sendEmail)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
            _sendEmail = sendEmail;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LoginUser(UserDto user)
        {
            try
            {
                if (user.EMAIL != null || user.PASSWORD != null)
                {
                    var pass = _tokenProvider.EncryptString(user.PASSWORD);
                    var userToken = _tokenProvider.LoginUser(user.EMAIL.Trim(), pass);

                    if (userToken != null)
                    {
                        HttpContext.Session.SetString("JWToken", userToken);
                        return Json(new { status = true });
                    }
                    else
                        return Json(new { status = false });
                }
                return Json(new { status = false });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
        public IActionResult NotFound404()
        {
            return View();
        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult ResetPassword(string token)
        {
            return View();
        }
        public IActionResult NewMember()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendNewMember(string name, string surname, string email, string note)
        {
            try
            {
                if (name == null)
                    return Json(new { status = false, error = "null", text = "Isim Bos Olamaz." });
                else if (surname == null)
                    return Json(new { status = false, error = "null", text = "Soyad Bos Olamaz." });
                else if (email == null)
                    return Json(new { status = false, error = "null", text = "Email Bos Olamaz." });

                var subject = "SHAM - Yeni Üye İsteği";
                var Message = EmailContents.NewMember(name, surname, email, note);
                var admins = _employeeRepository.GetAllEmployeeNewMember().Where(e => e.ROLE == Roles.ADMIN).Select(e => e.MAIL);

                foreach (var item in admins)
                {
                    _sendEmail.Send(subject, item, Message);
                }
                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
    }
}