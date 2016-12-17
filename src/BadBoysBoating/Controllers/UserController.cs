using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BadBoysBoating.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "customer, client")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bids()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }
    }
}
