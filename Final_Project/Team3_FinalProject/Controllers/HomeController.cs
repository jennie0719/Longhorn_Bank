using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team3_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Team3_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/StaffHome
        public IActionResult StaffHome()
        {
            return View();
        }
    }
}

