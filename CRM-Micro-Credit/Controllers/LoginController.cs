using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Entity.Models;
using CRM_Micro_Credit.Helpers;
using CRM_Micro_Credit.Interfaces;
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
        //private readonly string salt;
        private SmsHelper smsHelper = new SmsHelper();
        private DataContext dataContext { get; set; }
        public LoginController([FromServices] DataContext dataContext) //, IOptions<Salt> salt
        {
            //this.salt = salt.Value.SaltValue;
            this.dataContext = dataContext;
        }

        [AllowAnonymous]
        public IActionResult Index(string ReturnUrl)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Redirect("/Lk");
            }

            ILoginPage loginPage = new LoginPageModel();

            return View(loginPage);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginPageModel loginPage)
        {
            if (!ModelState.IsValid)
            {
                return View(loginPage);
            }

            var Code = smsHelper.SendSMS(loginPage.Mobile, dataContext);

            if (loginPage.ValidationCode == null)
            {
                loginPage.ValidationCode = "";
                return View(loginPage);
            }
            else
            {
                if (Code != loginPage.ValidationCode)
                {
                    ViewData["ErrorMessage"] = "Неверный код!";
                    return View(loginPage);
                }

                var user = dataContext.Users.FirstOrDefault(x=>x.Mobile == loginPage.Mobile);

                var dict = new Dictionary<string, string>();
                dict.Add(ClaimTypes.MobilePhone, loginPage.Mobile);
                dict.Add(ClaimTypes.Name, loginPage.Mobile);
                dict.Add(ClaimTypes.Role, user?.Role ?? new User().Role);

                ClaimsHelper.SetCookie(HttpContext, dict);

                return Redirect("/InfoCredit");
            }

        }

        
        

        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Lk");
        }
    }
}
