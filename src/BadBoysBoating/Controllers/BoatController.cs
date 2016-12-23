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
                    case 0: return RedirectToAction("Products", "User");
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
                    case 0: return RedirectToAction("Products", "User");
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
    }
}
