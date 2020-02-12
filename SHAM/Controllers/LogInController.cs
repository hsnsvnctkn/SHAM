using System;
using System.Collections.Generic;
using System.Linq;
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
        //readonly UserManager<IdentityUser> _userManager;

        public LogInController(ITokenProvider tokenProvider, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginUser(UserDto user)
        {
            var userToken = _tokenProvider.LoginUser(user.EMAIL.Trim(), user.PASSWORD.Trim());

            if (userToken != null)
                HttpContext.Session.SetString("JWToken", userToken);
            else
                return Redirect("~/LogIn/Index");

            return Redirect("~/Home/Index");
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
    }
}