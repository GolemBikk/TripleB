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
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ICollection<IFormFile> files, BoatViewModel model)
        {
            if (ModelState.IsValid && files.Count > 0)
            {
                BoatService service = new BoatService();
                int boat_id = service.AddBoat(model);
                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        byte[] CoverImageBytes = null;
                        BinaryReader reader = new BinaryReader(file.OpenReadStream());
                        CoverImageBytes = reader.ReadBytes((int)file.Length);
                    }
                }
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
        public async Task<IActionResult> Edit(BoatViewModel model)
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
