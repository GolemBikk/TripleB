using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;

namespace BadBoysBoating.Controllers
{
    public class HomeController : Controller
    {
        private BoatService service;

        public HomeController()
        {
            service = new BoatService();
        }

        public IActionResult Index()
        {          
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Rent(int page_num = 1)
        {
            List<BoatCollectionViewModel> boats = service.GetAllBoat(new PageInfo { PageNumber = page_num, PageSize = 9 }, "rent");
            return View(boats);
        }

        public IActionResult Sale()
        {
            return View();
        }

        public IActionResult Product(int boat_id)
        {
            BoatViewModel boat = service.GetBoatInfo(boat_id);
            return View(boat);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
