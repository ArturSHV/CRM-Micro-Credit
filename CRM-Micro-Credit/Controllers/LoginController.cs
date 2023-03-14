using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Entity.Models;
using CRM_Micro_Credit.Helpers;
using CRM_Micro_Credit.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace CRM_Micro_Credit.Controllers
{
    [Authorize(Policy = "Users")]
    public class LoginController : Controller
    {
        private SmsHelper smsHelper = new SmsHelper();
        private DataContext dataContext { get; set; }
        public LoginController([FromServices] DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }

        [AllowAnonymous]
        public IActionResult Index(string ReturnUrl)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Redirect($"/{nameof(ProfileController)[..^10]}");
            }

            LoginPageModel loginPage = new LoginPageModel() { Login = new Login()};

            return View(loginPage);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(LoginPageModel loginPage)
        {
            if (!ModelState.IsValid)
            {
                return View(loginPage);
            }

            var Code = smsHelper.SendSMS(loginPage.Login.Mobile, dataContext);

            if (loginPage.Login.ValidationCode == null)
            {
                loginPage.Login.ValidationCode = "";
                return View(loginPage);
            }
            else
            {
                if (Code != loginPage.Login.ValidationCode)
                {
                    ViewData["ErrorMessage"] = "Неверный код!";
                    return View(loginPage);
                }

                var user = dataContext.Users.Where(x=>x.Mobile == loginPage.Login.Mobile).FirstOrDefault();

                if (user == null)
                {
                    dataContext.Users.Add(new User() { Mobile = loginPage.Login.Mobile, Email = loginPage.Login.Email});

                    dataContext.SaveChanges();
                }

                var dict = new Dictionary<string, string>();
                dict.Add(ClaimTypes.MobilePhone, loginPage.Login.Mobile);
                dict.Add(ClaimTypes.Name, loginPage.Login.Mobile);
                dict.Add(ClaimTypes.Role, user?.Role ?? new User().Role);

                ClaimsHelper.SetCookieAsync(HttpContext, dict);

                return Redirect($"/{nameof(InfoCreditController)[..^10]}");
            }

        }


        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect($"/{nameof(HomeController)[..^10]}");
        }
    }
}
