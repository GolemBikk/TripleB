using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BadBoysBoating.Controllers
{
    public class HomeController : Controller
    {
        private BoatService b_service;
        private NewsService n_service;

        public HomeController()
        {
            b_service = new BoatService();
            n_service = new NewsService();
        }

        public async Task<IActionResult> Index()
        {
            ViewData["StyleSheet"] = "Index";
            ViewData["Login"] = CheckCookies();
            List<NewsCollectionViewModel> model = n_service.GetAllNews(new PageInfo { PageNumber = 1, PageSize = 5});
            if (ViewData["Login"].ToString().Length > 0 && ViewData["Role"].ToString().Equals("admin"))
            {
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }               

        public IActionResult Product(int boat_id)
        {
            BoatViewModel boat = b_service.GetBoatInfo(boat_id);
            return View(boat);
        }

        public IActionResult About()
        {
            ViewData["StyleSheet"] = "About";
            ViewData["Login"] = CheckCookies();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["StyleSheet"] = "Contact";
            ViewData["Login"] = CheckCookies();
            return View();
        }

        public IActionResult Error()
        {
            return View();
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
