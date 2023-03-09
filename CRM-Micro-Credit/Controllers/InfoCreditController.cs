using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRM_Micro_Credit.Controllers
{
    [Authorize(Policy = "Users")]
    public class InfoCreditController : Controller
    {
        private DataContext dataContext { get; set; }
        public InfoCreditController([FromServices] DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var phoneNumber = GetClaimValue(nameof(ClaimTypes.MobilePhone).ToLower());

            var user = dataContext.Users.FirstOrDefault(x => x.Mobile == phoneNumber);

            return View(user ?? new User());
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            user.Mobile = GetClaimValue(nameof(ClaimTypes.MobilePhone).ToLower());

            dataContext.Users.Add(user);

            await dataContext.SaveChangesAsync();

            return View(user);
        }

        private string GetClaimValue(string type)
        {
            return User.Claims.Where(x => x.Type.Contains(type)).First().Value;
        }
    }
}
