using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BadBoysBoating.Controllers
{
    public class RecallController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
