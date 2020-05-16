using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace v3x.Controllers
{
    public class EmployeeController : Controller
    {
        const string veryrole = "EMPLOYEE";
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}