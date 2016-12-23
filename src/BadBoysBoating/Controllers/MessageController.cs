using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;

namespace BadBoysBoating.Controllers
{
    public class MessageController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AddComment(MessageViewModel model)
        {
            
            return RedirectToAction("", "");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int comment_id)
        {
            return RedirectToAction("", "");
        }

        [HttpPost]
        public async Task<IActionResult> Buy(MessageViewModel model)
        {
            return RedirectToAction("", "");
        }

        [HttpPost]
        public async Task<IActionResult> Rent(MessageViewModel model)
        {
            return RedirectToAction("", "");
        }

        [HttpPost]
        public async Task<IActionResult> Answer(int recal_id, bool answer)
        {
            return RedirectToAction("", "");
        }

        [HttpPost]
        public async Task<IActionResult> Complaint(int message_id)
        {
            MessageService service = new MessageService();
            service.AddComplaint(message_id);
            return RedirectToAction("", "");
        }
    }
}
