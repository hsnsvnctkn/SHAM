﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SHAM.Repository.Authorize;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using SHAM.UI.Models;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace SHAM.Controllers
{
    [Authorize(Roles.NORMAL, Roles.ADMIN)]
    public class HomeController : Controller
    {
        private readonly IIndexRepository _indexRepository;
        private readonly IPublicHolidays _publicHolidays;

        public HomeController(IIndexRepository indexRepository, IPublicHolidays publicHolidays)
        {
            _indexRepository = indexRepository;
            _publicHolidays = publicHolidays;
        }
        public IActionResult Index()
        {
            var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = claimsIndentity.Claims;
            string id = "";
            bool isAdmin = false;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                foreach (var claim in userClaims)
                {
                    var cType = claim.Type;
                    var cValue = claim.Value;
                    switch (cType)
                    {
                        case "ID":
                            id = cValue;
                            break;
                        case Roles.ADMIN:
                            isAdmin = true;
                            break;
                    }
                }
            }

            var model = _indexRepository.GetAdminIndex(Convert.ToInt16(id), isAdmin);
            model.DaysSummary = _publicHolidays.GetMonthHolidays(DateTime.Now.Month, DateTime.Now.Year);

            return View(model);
        }
        public IActionResult SetSessionMenuList(string key,string value)
        {
            HttpContext.Session.SetString(key, value);
            return this.Json(new { success = true });
        }
    }
}
