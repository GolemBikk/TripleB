using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace BadBoysBoating.Controllers
{
    public class UserController : Controller
    {
        private int account_id;

        [Authorize(Roles = "admin, customer, client")]
        public IActionResult Index(int page_num = 1)
        {
            AuthorizationService a_service = new AuthorizationService();
            AccountViewModel account = a_service.GetAccountInfo(User.Identity.Name);
            if (account.AccountType.Equals("customer"))
            {
                MessageService r_service = new MessageService();
                account.Recalls = r_service.GetInbox(account.Id);
                BoatService b_service = new BoatService();
                account.Boats = b_service.GetUsersBoat(account.Id);

            }
            ViewData["StyleSheet"] = "Profile";
            ViewData["Login"] = CheckCookies();
            return View(account);
        }

        [Authorize(Roles = "customer, client")]
        public IActionResult Recalls(string recalls_type)
        {
            InitializeAccountId();
            List<MessageViewModel> recalls = null;
            switch (recalls_type)
            {
                case "outbox":
                    {
                        MessageService r_service = new MessageService();
                        recalls = null;
                    }
                    break;
                case "inbox":
                    {
                        MessageService r_service = new MessageService();
                        recalls = null;
                    }
                    break;
            }
            return View(recalls);
        }

        [Authorize(Roles = "customer")]
        public IActionResult Products(int page_num = 1)
        {
            InitializeAccountId();
            BoatService service = new BoatService();
            List<BoatCollectionViewModel> boats = service.GetUsersBoat(account_id);
            return View(boats);
        }

        private void InitializeAccountId()
        {
            AuthorizationService service = new AuthorizationService();
            AccountViewModel account = service.GetAccountInfo(User.Identity.Name);
            account_id = account.Id;
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
