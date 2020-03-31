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
    [Authorize(Roles.NORMAL, Roles.ADMIN)]
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
            var model = _activityRepository.GetMonthList();
            return View(model);
        }

        [Authorize(Roles.ADMIN)]
        [HttpPost]
        public IActionResult Index(bool All)
        {
            if (All == true)
            {
                var model = _activityRepository.GetList();
                return View(model);
            }
            else
                return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        public JsonResult Create(ActivityDto activity)
        {
            try
            {
                var x = activity.START_TIME == null;

                if (x == true || activity.WHOUR == 0 || activity.ACTIVITY_DATE == DateTime.MinValue)
                    return Json(new { status = false, error = "any" });

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

                if (activity.END_TIME <= activity.START_TIME)
                    return Json(new { status = false, error = "EndTimeSmall" });

                _activityRepository.Create(activity);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false, error = "any" });
            }
        }
        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        [HttpPost]
        public JsonResult Edit(ActivityDto activity)
        {
            try
            {
                if (activity.START_TIME == TimeSpan.Zero || activity.WHOUR == 0 || activity.ACTIVITY_DATE == DateTime.MinValue)
                    return Json(new { status = false, error = "any" });

                if (activity.END_TIME <= activity.START_TIME)
                    return Json(new { status = false, error = "EndTimeSmall" });

                activity.WHOUR = Math.Round(activity.WHOUR, 2);

                _activityRepository.Update(activity);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false, error = "any" });
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
        [HttpPost]
        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        [ValidateAntiForgeryToken]
        public IActionResult MyDelete(int id)
        {
            try
            {
                _activityRepository.Delete(id);

                return RedirectToAction("MyActivity");
            }
            catch (Exception)
            {

                return NotFound("Hata");
            }
        }

        [Authorize(Roles.ADMIN, Roles.NORMAL)]
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

        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        [HttpPost]
        public IActionResult MyActivity(bool All)
        {
            if (All == true)
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
                var model = _activityRepository.GetMyAllActivity(Convert.ToInt16(id));

                return View(model);
            }
            else
                return RedirectToAction(nameof(MyActivity));
        }
    }
}