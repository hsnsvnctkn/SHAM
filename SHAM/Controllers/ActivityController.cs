using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Authorize;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    [Authorize(Roles.NORMAL,Roles.ADMIN)]
    public class ActivityController : Controller
    {
        readonly IActivityRepository _activityRepository;
        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        [Authorize(Roles.ADMIN)]
        public IActionResult Index()
        {
            var model = _activityRepository.GetList();
            return View(model);
        }
        [Authorize(Roles.ADMIN)]
        public JsonResult Create(ActivityDto activity)
        {
            try
            {
                var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = claimsIndentity.Claims;
                string id = "";
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
                        }
                    }
                }
                activity.CREATOR = Convert.ToInt16(id);
                activity.ACTIVITY_EMPLOYEE = Convert.ToInt16(id);

                _activityRepository.Create(activity);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }
        [Authorize(Roles.ADMIN)]
        public JsonResult Edit(ActivityDto activity)
        {
            try
            {
                _activityRepository.Update(activity);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }

        [HttpPost]
        [Authorize(Roles.ADMIN)]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {

                _activityRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound("Hata");
            }
        }
        public IActionResult MyActivity()
        {
            var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = claimsIndentity.Claims;
            string id = "";
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
                    }
                }
            }

            var model = _activityRepository.GetMyActivity(Convert.ToInt16(id));
            return View(model);
        }

    }
}