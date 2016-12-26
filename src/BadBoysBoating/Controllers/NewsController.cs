using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Business;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Localization;
using System.Security.Claims;

namespace BadBoysBoating.Controllers
{
    public class NewsController : Controller
    {
        private NewsService n_service;

        public NewsController()
        {
            n_service = new NewsService();
        }

        public IActionResult Index(int page_num = 1)
        {
            ViewData["StyleSheet"] = "Previews";
            ViewData["Login"] = CheckCookies();
            ViewData["CurentPage"] = page_num;
            ViewData["TotalPages"] = n_service.GetPagesCount(3);
            List<NewsCollectionViewModel> model = n_service.GetAllNews(new PageInfo { PageNumber = page_num, PageSize = 3 });
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditNews(int news_id)
        {
            NewsViewModel model = n_service.GetNewsInfo(news_id);            
            return View(model);
        }

        [HttpGet]
        public IActionResult FullNews(int news_id, int page_num = 1)
        {
            NewsViewModel model = n_service.GetNewsInfo(news_id);
            ViewData["CurentPage"] = page_num;
            ViewData["StyleSheet"] = "News";
            ViewData["Login"] = CheckCookies();
            return View(model);
        }

        public async Task<IActionResult> DeleteNews(int news_id)
        {
            n_service.DeleteNews(news_id);
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

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        private string CheckCookies()
        {
            if (User.Identity.Name != null)
            {
                ViewData["Role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                return User.Identity.Name;
            }
            else
            {
                return "";
            }
        }
    }
}
