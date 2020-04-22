using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nager.Date;
using SHAM.Repository.Authorize;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly ITokenProvider _tokenProvider;

        public EmployeeController(IEmployeeRepository employeeRepository, ITokenProvider tokenProvider)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
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
                if (!_employeeRepository.IsAnyEmployee(employee.MAIL))
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
                    employee.CREATOR_ID = Convert.ToInt16(id);
                    employee.PASSWORD = _tokenProvider.EncryptString("test");

                    _employeeRepository.Create(employee);
                    return Json(new { status = true });
                }
                else
                    return Json(new { status = false, error = "thereIsEmployee" });
            }
            catch (Exception)
            {

                return Json(new { status = false, error = "any" });
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
        public IActionResult Reports()
        {
            var employeesId = _employeeRepository.GetEmployeesId();

            ViewData["month"] = DateTime.Now.Month;
            ViewData["year"] = DateTime.Now.Year;

            return View(employeesId);
        }
        [HttpPost]
        public IActionResult Reports(int id, int month, int year)
        {
            try
            {
                var reports = _employeeRepository.GetReports(id, month, year);
                ViewData["month"] = month;
                ViewData["year"] = year;

                return View(reports);
            }
            catch (Exception e)
            {

                return Json(new { status = false, error = e });
            }
        }
    }
}