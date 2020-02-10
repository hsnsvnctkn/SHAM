﻿using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Authorize;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class LevelController : Controller
    {
        readonly ILevelRepository _levelRepository;

        public LevelController(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public IActionResult Index()
        {
            var model = _levelRepository.GetList();
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var level = _levelRepository.Get(id);

            if (level == null)
                return NotFound("Silinecek birşey bulunamadı !");

            _levelRepository.DeleteLevel(level.ID);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,NAME")] ConstantDto level)
        {
            if (level.NAME != null)
            {
                _levelRepository.Create(level);
                return RedirectToAction(nameof(Index));
            }

            return View(level);

        }

        [HttpPost]
        public JsonResult Edit(ConstantDto data)
        {
            try
            {
                _levelRepository.Update(data);
                return Json(new { Status = true });
            }
            catch (System.Exception)
            {
                return Json(new { Status = false });
            }

        }

    }
}

