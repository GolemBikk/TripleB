using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;

namespace BadBoysBoating.Controllers
{
    public class BoatController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBoat(BoatViewModel model)
        {
            if (ModelState.IsValid)
            {
                BoatService service = new BoatService();
                service.AddBoat(model);
                return RedirectToAction("Products", "User");
            }
            else
            {
                ModelState.AddModelError("", "Ошибка при добавлении записи");
                return RedirectToAction("Products", "User");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBoat(BoatViewModel model)
        {
            if (ModelState.IsValid)
            {
                BoatService service = new BoatService();
                service.AddBoat(model);
                return RedirectToAction("Products", "User");
            }
            else
            {
                ModelState.AddModelError("", "Ошибка при редактировании записи");
                return RedirectToAction("Products", "User");
            }
        }
    }
}
