using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Business;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BadBoysBoating.Controllers
{
    public class NewsController : Controller
    {
        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditNews(int boat_id)
        {
            NewsService service = new NewsService();
            NewsViewModel model = service.GetNewsInfo(boat_id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNews(ICollection<IFormFile> files, NewsViewModel model)
        {
            if (ModelState.IsValid && files.Count > 0)
            {
                List<String> text = model.Text;
                model.Images = new List<Byte[]>();

                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        BinaryReader reader = new BinaryReader(file.OpenReadStream());
                        model.Images.Add(reader.ReadBytes((int)file.Length));
                    }
                }

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
