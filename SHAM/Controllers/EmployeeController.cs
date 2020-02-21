using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Authorize;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var model = _employeeRepository.GetList();
            return View(model);
        }
        [HttpPost]
        public JsonResult Create(EmployeeDto employee)
        {
            try
            {
                _employeeRepository.Create(employee);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }

        public JsonResult Edit(EmployeeDto employee)
        {
            try
            {
                _employeeRepository.Update(employee);
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
                var emp = _employeeRepository.Get(id);

                if (emp == null)
                    return NotFound("Silinecek birşey bulunamadı !");

                _employeeRepository.Delete(emp.ID);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound("Hata");
            }
        }
    }
}