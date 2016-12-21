using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Business;

namespace BadBoysBoating.Controllers
{
    public class NewsController : Controller
    {
        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNews(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<String> text = model.Text;

                foreach (String item in text.First().Split(new char[] {'\r','\n'}))
                {
                    if (item.Length > 0)
                    {
                        model.Text.Add(item);
                    }
                }
                
                model.Text.Remove(model.Text.First());
                NewsService service = new NewsService();
                service.AddNews(model);
                return RedirectToAction("News", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return RedirectToAction("News", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> EditNews(NewsViewModel model)
        {
            throw new Exception();
        }
    }
}
