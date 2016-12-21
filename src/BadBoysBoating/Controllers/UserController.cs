using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BadBoysBoating.Controllers
{
    public class UserController : Controller
    {
        private int account_id;

        [Authorize(Roles = "admin, customer, client")]
        public IActionResult Index()
        {
            AuthorizationService service = new AuthorizationService();
            AccountViewModel account = service.GetAccountInfo(User.Identity.Name);
            return View(account);
        }

        [Authorize(Roles = "customer, client")]
        public IActionResult Recalls(string recalls_type)
        {
            InitializeAccountId();
            List<RecallCollectionViewModel> recalls = null;
            switch (recalls_type)
            {
                case "outbox":
                    {
                        RecallService r_service = new RecallService();
                        recalls = r_service.GetOutbox(account_id);
                    }
                    break;
                case "inbox":
                    {
                        RecallService r_service = new RecallService();
                        recalls = r_service.GetInbox(account_id);
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
            List<BoatCollectionViewModel> boats = service.GetUsersBoat(new PageInfo { PageNumber = page_num, PageSize = 9}, account_id);
            return View(boats);
        }

        private void InitializeAccountId()
        {
            AuthorizationService service = new AuthorizationService();
            AccountViewModel account = service.GetAccountInfo(User.Identity.Name);
            account_id = account.Id;
        }
    }
}
