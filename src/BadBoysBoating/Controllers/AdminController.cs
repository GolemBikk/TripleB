using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ViewModels;
using Business;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace BadBoysBoating.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }

        public IActionResult News(int page_num = 1)
        {
            NewsService service = new NewsService();
            List<NewsCollectionViewModel> news = service.GetAllNews(new PageInfo { PageNumber = page_num, PageSize = 10 });
            return View(news);
        }

        public IActionResult AddNews()
        {
            return View();
        }

        public IActionResult EditNews(int id)
        {
            NewsService service = new NewsService();
            NewsViewModel news = service.GetNewsInfo(id);
            return View(news);
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
    }
}
