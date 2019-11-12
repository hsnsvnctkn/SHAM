using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Contracts;
using SHAM.UI.Models;
using System.Linq;

namespace SHAM.UI.Controllers
{
    public class TitleController : Controller
    {
        readonly ITitleRepository _titleRepository;
        public TitleController(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public IActionResult Index()
        {
            var list = _titleRepository.GetList();
            var model = list.Select(x => new TitleViewModel { ID = x.ID, Name = x.TITLE_NAME }).ToList();
            return View(model);
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}