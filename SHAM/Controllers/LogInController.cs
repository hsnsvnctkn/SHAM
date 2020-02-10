using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    public class LogInController : Controller
    {
        readonly ITokenProvider _tokenProvider;

        public LogInController(ITokenProvider tokenProvider)
        {
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

    }
}