using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace BadBoysBoating.Controllers
{
    public class NewsController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> AddNews(NewsViewModel model)
        {
            throw new Exception();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> EditNews(NewsViewModel model)
        {
            throw new Exception();
        }
    }
}
