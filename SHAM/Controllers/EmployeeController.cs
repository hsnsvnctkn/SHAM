using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;

namespace SHAM.UI.Controllers
{
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
        public IActionResult Create(EmployeeDto employee)
        {
            if(employee!=null)
            {
                _employeeRepository.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            return NotFound("Eklenecek bişey bulunamadı !");
        }
    }
}