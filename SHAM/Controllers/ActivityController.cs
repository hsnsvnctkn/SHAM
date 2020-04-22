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
            {
                var model = _activityRepository.GetMonthList();
                return View(model);
            }
        }

        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        public JsonResult Create(ActivityDto activity)
        {
            try
            {
                if (activity.PROJECT_NUMBER == null)
                    return Json(new { status = false, error = "Proje seçimi yapınız.." });
                else if (activity.ACTIVITY_DATE == DateTime.MinValue)
                    return Json(new { status = false, error = "Aktivite tarihi boş bırakılamaz.." });
                else if (activity.START_TIME == null)
                    return Json(new { status = false, error = "Başlangıç saati boş bırakılamaz.." });
                else if (activity.WHOUR == 0)
                    return Json(new { status = false, error = "Çalışma saati boş bırakılamaz.." });
                else if (activity.ACTIVITY_DETAIL == null)
                    return Json(new { status = false, error = "Detay boş bırakılamaz.." });
                else if (activity.END_TIME <= activity.START_TIME)
                    return Json(new { status = false, error = "Aktivite başlangıç saati bitişinden küçük olamaz.." });


                var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = claimsIndentity.Claims;
                string id = "", newName = "";
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
                            case ClaimTypes.Name:
                                newName = cValue;
                                break;
                            case ClaimTypes.Surname:
                                newName += " " + cValue;
                                break;
                        }
                    }
                }
                activity.CREATOR = Convert.ToInt16(id);
                activity.ACTIVITY_EMPLOYEE = Convert.ToInt16(id);
                activity.WHOUR = Math.Round(activity.WHOUR, 2);


                _activityRepository.Create(activity);
                var newId = _activityRepository.GetLastActivityId();
                return Json(new { status = true, id = newId, name = newName });
            }
            catch (Exception e)
            {

                return Json(new { status = false, error = e });
            }
        }
        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        [HttpPost]
        public JsonResult Edit(ActivityDto activity)
        {
            try
            {
                if (activity.PROJECT_NUMBER == null)
                    return Json(new { status = false, error = "Proje seçimi yapınız.." });
                else if (activity.ACTIVITY_DATE == DateTime.MinValue)
                    return Json(new { status = false, error = "Aktivite tarihi boş bırakılamaz.." });
                else if (activity.START_TIME == null)
                    return Json(new { status = false, error = "Başlangıç saati boş bırakılamaz.." });
                else if (activity.WHOUR == 0)
                    return Json(new { status = false, error = "Çalışma saati boş bırakılamaz.." });
                else if (activity.ACTIVITY_DETAIL == null)
                    return Json(new { status = false, error = "Detay boş bırakılamaz.." });
                else if (activity.END_TIME <= activity.START_TIME)
                    return Json(new { status = false, error = "Aktivite başlangıç saati bitişinden küçük olamaz.." });

                activity.WHOUR = Math.Round(activity.WHOUR, 2);

                _activityRepository.Update(activity);
                return Json(new { status = true });
            }
            catch (Exception e)
            {

                return Json(new { status = false, error = e });
            }
        }

        [HttpPost]
        [Authorize(Roles.ADMIN)]
        public JsonResult Delete(int id)
        {
            try
            {
                _activityRepository.Delete(id);

                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
        [HttpPost]
        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        public JsonResult MyDelete(int id)
        {
            try
            {
                _activityRepository.Delete(id);

                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
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