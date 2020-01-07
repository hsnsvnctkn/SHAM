using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;

namespace SHAM.UI.Controllers
{
    public class ProjectController : Controller
    {
        readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public IActionResult Index()
        {
            var model = _projectRepository.GetList();
            return View(model);
        }
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

        public JsonResult Create(ProjectDto project)
        {
            try
            {
                _projectRepository.Create(project);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }

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


    }
}