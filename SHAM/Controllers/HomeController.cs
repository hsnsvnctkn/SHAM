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

        public HomeController(IIndexRepository indexRepository)
        {
            _indexRepository = indexRepository;
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
            Repository.PublicHolidays.loadPublicHolidays();

            var model = _indexRepository.GetAdminIndex(Convert.ToInt16(id), isAdmin);

            return View(model);
        }
    }
}
