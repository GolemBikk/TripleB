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
        public IActionResult EditNews(int news_id)
        {
            NewsService service = new NewsService();
            NewsViewModel model = service.GetNewsInfo(news_id);

            return View(model);
        }

        [HttpGet]
        public IActionResult FullNews(int news_id)
        {
            NewsService service = new NewsService();
            NewsViewModel model = service.GetNewsInfo(news_id);

            return View(model);
        }

        public async Task<IActionResult> DeleteNews(int news_id)
        {
            NewsService service = new NewsService();
            service.DeleteNews(news_id);

            return RedirectToAction("News", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNews(ICollection<IFormFile> files, NewsViewModel model)
        {
            if (ModelState.IsValid && files.Count > 0)
            {
                model.Images = new List<Byte[]>();

                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        BinaryReader reader = new BinaryReader(file.OpenReadStream());
                        model.Images.Add(reader.ReadBytes((int)file.Length));
                    }
                }

                //foreach (String item in text.First().Split(new char[] {'\r','\n'}))
                //{
                //    if (item.Length > 0)
                //    {
                //        model.Text.Add(item);
                //    }
                //}
                
                //model.Text.Remove(model.Text.First());
                NewsService service = new NewsService();
                service.AddNews(model);
                return RedirectToAction("News", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Некорректно введены данные");
            }
            return RedirectToAction("News", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNews(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                NewsService service = new NewsService();
                service.EditNews(model);
                return RedirectToAction("News", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Некорректно введены данные");
            }
            return RedirectToAction("EditNews", "Admin");
        }
    }
}
