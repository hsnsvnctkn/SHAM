using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SHAM.Repository;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    public class LogInController : Controller
    {
        readonly ITokenProvider _tokenProvider;
        readonly IEmployeeRepository _employeeRepository;
        readonly IEmailSender _emailSender;
        //readonly UserManager<IdentityUser> _userManager;

        public LogInController(ITokenProvider tokenProvider, IEmployeeRepository employeeRepository, IEmailSender emailSender)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LoginUser(UserDto user)
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
        //public IActionResult SendPasswordResetLink(string email)
        //{
        //    try
        //    {
        //        var dtoUser = _employeeRepository.Get(email);
        //        IdentityUser user = new IdentityUser();
        //        if (dtoUser != null)
        //        {
        //            user.Email = dtoUser.EMAIL;
        //            user.UserName = dtoUser.EMAIL;

        //            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;

        //            var resetLink = Url.Action("ResetPassword", "Account", new { token = token }, protocol: HttpContext.Request.Scheme);
        //            ViewBag.Message = "Parola sıfırlama bağlantısı e posta adresinize gönderildi!";
        //            return Redirect("~/LogIn/Index");
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Girdiğiniz Mail Adresi Yanlış !!";
        //            return View("Error");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
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
            if (name == null)
                return Json(new { status = false, error = "null", text = "Isim Bos Olamaz." });
            else if (surname == null)
                return Json(new { status = false, error = "null", text = "Soyad Bos Olamaz." });
            else if (email == null)
                return Json(new { status = false, error = "null", text = "Email Bos Olamaz." });

            var msg = new MimeMessage();

            var subject = "SHAM - Yeni Üye İsteği";
            var body = "<b>Ad</b> : " + name + "<br>" + "<b>Soyad</b> : " + surname + "<br>" + "<b>Mail Adresi </b>: " + email + "<br>" + "<b>Notu</b> : " + note;
            var adress = "sevinctekin.hasan@gmail.com";

            _emailSender.Send(adress, subject, body);

            return Json(new { status = true });
        }
    }
}