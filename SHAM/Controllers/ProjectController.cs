using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Contracts;

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
    }
}