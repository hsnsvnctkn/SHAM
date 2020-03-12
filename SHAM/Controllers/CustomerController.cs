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
    [Authorize(Roles.ADMIN)]
    public class CustomerController : Controller
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var model = _customerRepository.GetList();
            return View(model);
        }
        public JsonResult Create(CustomerDto employee)
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
                employee.CREATOR_ID = Convert.ToInt16(id);

                _customerRepository.Create(employee);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }

        [HttpPost]
        public JsonResult Edit(CustomerDto customer)
        {
            try
            {
                _customerRepository.Update(customer);
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

                _customerRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound("Hata");
            }
        }


    }
}