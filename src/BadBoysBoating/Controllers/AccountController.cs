using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;
using System.Security.Claims;

namespace BadBoysBoating.Controllers
{
    public class AccountController : Controller
    {
        private AuthorizationService service;

        public AccountController()
        {
            service = new AuthorizationService();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                int code = service.RegisterNewAccount(model);
                switch (code)
                {
                    case 0:
                        {
                            AccountViewModel account = service.GetAccountInfo(model.UserLogin);
                            await Authenticate(account);
                            return RedirectToAction("Index", "Home");
                        }
                    case 1: ModelState.AddModelError("", "Логин уже занят другим пользователем"); break;
                    case 2: ModelState.AddModelError("", "Электронный адрес уже занят другим пользователем"); break;
                    case 3: ModelState.AddModelError("", "Неизвестная ошибка"); break;
                }
            }
            else
            {
                ModelState.AddModelError("", "Некорректные регистрационные данные");
            }
            return RedirectToAction("Register", "Account", model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                int code = service.CheckPassword(model);
                switch (code)
                {
                    case 0:
                        {
                            AccountViewModel account = service.GetAccountInfo(model.UserLogin);
                            await Authenticate(account);
                            return RedirectToAction("Index", "Home");
                        }
                    case 1: ModelState.AddModelError("", "Неверно указанный пароль"); break;
                    case 2: ModelState.AddModelError("", "Пользователя с таким логином не существует"); break;
                }
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return RedirectToAction("Login", "Account", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AuthorizationService service = new AuthorizationService();
                service.EditAccount(model);
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(AccountViewModel account)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, account.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, account.AccountType)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
        }
    }
}
