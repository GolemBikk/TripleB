using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

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

        public IActionResult Index()
        {
            ViewData["StyleSheet"] = "Index";
            ViewData["Login"] = CheckCookies();
            List<NewsCollectionViewModel> model = n_service.GetAllNews(new PageInfo { PageNumber = 1, PageSize = 5});
            return View(model);
        }       

        public IActionResult Rent(int page_num = 1)
        {
            List<BoatCollectionViewModel> boats = b_service.GetAllBoat(new PageInfo { PageNumber = page_num, PageSize = 9 }, "rent");
            return View(boats);
        }

        public IActionResult Sale()
        {
            return View();
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
                return User.Identity.Name;
            }
            else
            {
                return "";
            }
        }
    }
}
