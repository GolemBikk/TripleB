using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace BadBoysBoating.Controllers
{
    public class BoatController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            BoatService service = new BoatService();
            BoatViewModel model = service.GetBoatInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ICollection<IFormFile> files, BoatViewModel model)
        {
            if (ModelState.IsValid && files.Count > 0)
            {
                BoatService service = new BoatService();
                AuthorizationService a_service = new AuthorizationService();
                model.Owner = a_service.GetAccountInfo(User.Identity.Name).Id;
                model.Images = new List<byte[]>();
                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        BinaryReader reader = new BinaryReader(file.OpenReadStream());
                        model.Images.Add(reader.ReadBytes((int)file.Length));
                    }
                }
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
        public async Task<IActionResult> Edit(ICollection<IFormFile> files, BoatViewModel model)
        {
            if (ModelState.IsValid && files.Count > 0)
            {
                BoatService service = new BoatService();
                service.EditBoat(model);
                return RedirectToAction("Products", "User");
            }
            else
            {
                ModelState.AddModelError("", "Ошибка при редактировании записи");
                return RedirectToAction("Products", "User");
            }
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
