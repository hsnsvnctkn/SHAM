using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Authorize;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Security.Claims;

namespace SHAM.UI.Controllers
{
    [Authorize(Roles.NORMAL,Roles.ADMIN)]
    public class ProjectController : Controller
    {
        readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        [Authorize(Roles.ADMIN)]
        public IActionResult Index()
        {
            var model = _projectRepository.GetList();
            return View(model);
        }
        [Authorize(Roles.ADMIN)]
        public JsonResult Edit(ProjectDto project)
        {
            try
            {
                _projectRepository.Update(project);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }
        [Authorize(Roles.ADMIN)]
        public JsonResult Create(ProjectDto project)
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
                project.CREATOR = Convert.ToInt16(id);

                _projectRepository.Create(project);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }
        [Authorize(Roles.ADMIN)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {

                _projectRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound("Hata");
            }
        }
        public IActionResult MyProject()
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

            var model = _projectRepository.GetMyProject(Convert.ToInt16(id));
            return View(model);
        }
    }
}