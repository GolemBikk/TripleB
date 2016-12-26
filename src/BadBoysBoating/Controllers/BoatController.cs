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
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        public IActionResult Sale(int page_num = 1)
        {
            ViewData["StyleSheet"] = "About";
            ViewData["Login"] = CheckCookies();
            BoatService service = new BoatService();
            List<BoatCollectionViewModel> boats = service.GetAllBoat(new PageInfo { PageNumber = page_num, PageSize = 9 }, "buy");
            return View(boats);
        }

        public IActionResult Rent(int page_num = 1)
        {
            ViewData["StyleSheet"] = "About";
            ViewData["Login"] = CheckCookies();
            BoatService service = new BoatService();
            List<BoatCollectionViewModel> boats = service.GetAllBoat(new PageInfo { PageNumber = page_num, PageSize = 9 }, "rent");
            return View(boats);
        }

        [Authorize(Roles = "admin, client, customer")]
        public IActionResult Product(int boat_id)
        {
            BoatService service = new BoatService();
            BoatViewModel boat = service.GetBoatInfo(boat_id);
            return View(boat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ICollection<IFormFile> files, BoatViewModel model)
        {
            if (ModelState.IsValid && files.Count > 0)
            {
                BoatService b_service = new BoatService();
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
                    else
                    {
                        ModelState.AddModelError("", "Присутствует пустой файл");
                        return RedirectToAction("Add", "Boat", model);
                    }
                }
                int code = b_service.AddBoat(model);
                switch (code)
                {
                    case 0: return RedirectToAction("Index", "User");
                    case 1:
                        {
                            ModelState.AddModelError("", "Ошибка при добавлении записи");
                        } break;
                }
            }
            else
            {
                ModelState.AddModelError("", "Неверное заполнение полей, либо остутствует изображение");              
            }
            return RedirectToAction("Add", "Boat", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BoatViewModel model)
        {
            if (ModelState.IsValid)
            {
                BoatService service = new BoatService();
                AuthorizationService a_service = new AuthorizationService();
                model.Owner = a_service.GetAccountInfo(User.Identity.Name).Id;
                int code = service.EditBoat(model);
                switch (code)
                {
                    case 0: return RedirectToAction("Index", "User");
                    case 1:
                        {
                            ModelState.AddModelError("", "Ошибка при редактировании записи");
                        }
                        break;
                }
            }
            else
            {
                ModelState.AddModelError("", "Неверное заполнение полей");                
            }
            return RedirectToAction("Edit", "Boat", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            BoatService service = new BoatService();
            service.DeleteBoat(id);
            return RedirectToAction("Products", "User");
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
