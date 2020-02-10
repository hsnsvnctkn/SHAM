using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    public class DashboardController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly ITokenProvider _tokenProvider;

        public DashboardController(IEmployeeRepository employeeRepository, ITokenProvider tokenProvider)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
        }
        public IActionResult Index()
        {
            UserDto loggedUser = new UserDto();
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = claimsIdentity.Claims;

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    foreach (var claim in userClaims)
                    {
                        var cType = claim.Type;
                        var cValue = claim.Value;

                        switch (cType)
                        {
                            case "ID":
                                loggedUser.ID = cValue;
                                break;
                            case ClaimTypes.Name:
                                loggedUser.NAME = cValue;
                                break;
                            case ClaimTypes.Surname:
                                loggedUser.SURNAME = cValue;
                                break;
                            case ClaimTypes.Email:
                                loggedUser.EMAIL = cValue;
                                break;
                            case "PASSWORD":
                                loggedUser.PASSWORD = cValue;
                                break;
                            case Roles.NORMAL:
                                loggedUser.ROLE = "Normal Kullanıcı";
                                break;
                            case Roles.ADMIN:
                                loggedUser.ROLE = "Admin";
                                break;
                            case "ADRESS":
                                loggedUser.ADRESS = cValue;
                                break;
                        }
                    }
                }
            }
            return View("Index", loggedUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMyInfo(UserDto user)
        {
            try
            {
                var userToken = _tokenProvider.LoginUser(user.EMAIL.Trim(), user.PASSWORD.Trim());

                if (userToken != null)
                {
                    UserDto loggedUser = new UserDto();
                    if (User.Identity.IsAuthenticated)
                    {
                        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                        var userClaims = claimsIdentity.Claims;

                        if (HttpContext.User.Identity.IsAuthenticated)
                        {
                            foreach (var claim in userClaims)
                            {
                                var cType = claim.Type;
                                var cValue = claim.Value;

                                switch (cType)
                                {
                                    case "ID":
                                        loggedUser.ID = cValue;
                                        break;
                                }
                            }
                            user.ID = loggedUser.ID;

                            _employeeRepository.UpdateMyInfo(user);
                            HttpContext.Session.Clear();
                            HttpContext.Session.SetString("JWToken", userToken);

                        }

                        return RedirectToAction(nameof(Index));

                    }
                }
                else
                    return NotFound("Yanlış şifre");
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMyPassword(string p1, string p2, string p3)
        {
            try
            {
                if (p2 == p3)
                {
                    UserDto loggedUser = new UserDto();
                    if (User.Identity.IsAuthenticated)
                    {
                        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                        var userClaims = claimsIdentity.Claims;

                        if (HttpContext.User.Identity.IsAuthenticated)
                        {
                            foreach (var claim in userClaims)
                            {
                                var cType = claim.Type;
                                var cValue = claim.Value;

                                switch (cType)
                                {
                                    case "ID":
                                        loggedUser.ID = cValue;
                                        break;
                                    case ClaimTypes.Email:
                                        loggedUser.EMAIL = cValue;
                                        break;
                                }
                            }
                            var userToken = _tokenProvider.LoginUser(loggedUser.EMAIL.Trim(), p1.Trim());

                            if (userToken != null)
                            {
                                _employeeRepository.UpdateMyPass(Convert.ToInt16(loggedUser.ID), p2);
                                HttpContext.Session.Clear();
                            }
                            else
                                return NotFound("Mevcut Şifre Yanlış");
                        }

                        return RedirectToAction("Index", "LogIn");

                    }

                }
                else
                    return NotFound("Şifreler eşleşmiyor");
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}