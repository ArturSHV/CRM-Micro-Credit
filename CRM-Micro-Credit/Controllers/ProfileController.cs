using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Entity.Models;
using CRM_Micro_Credit.Helpers;
using CRM_Micro_Credit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace CRM_Micro_Credit.Controllers
{
    [Authorize(Policy = "Users")]
    public class ProfileController : Controller
    {
        protected DataContext dataContext { get; set; }
        protected string logPath { get; set; }
        protected IQueryable<Education> educations { get; set; }
        protected IQueryable<Work> works { get; set; }
        protected IQueryable<User> users { get; set; }

        public ProfileController([FromServices] DataContext dataContext, IOptions<Settings> settings)
        {
            logPath = settings.Value.LogPath;

            this.dataContext = dataContext;

            educations = dataContext.Educations;

            works = dataContext.Works;

            users = dataContext.Users;
        }
        public IActionResult Index()
        {
            var phoneNumber = ClaimsHelper.GetClaimValue(User.Claims, nameof(ClaimTypes.MobilePhone).ToLower(), logPath);

            var user = users.FirstOrDefault(x => x.Mobile == phoneNumber) ?? new User();

            return View(new ProfilePageModel() { User = user, Educations = educations.ToList(), Works = works.ToList()});
        }


        [HttpPost]
        public async Task<IActionResult> Index(ProfilePageModel profilePage)
        {
            var phoneNumber = ClaimsHelper.GetClaimValue(User.Claims, nameof(ClaimTypes.MobilePhone).ToLower(), logPath);

            var user = users.FirstOrDefault(x => x.Mobile == phoneNumber);

            profilePage.User.Mobile = phoneNumber;

            if (user == null)
            {
                dataContext.Users.Add(profilePage.User);
            }
            else
            {
                profilePage.User.Id = user.Id;

                dataContext.Entry(user).CurrentValues.SetValues(profilePage.User);
            }

            await dataContext.SaveChangesAsync();

            return View(profilePage);
        }

    }
}
