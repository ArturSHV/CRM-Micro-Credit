using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Entity.Models;
using CRM_Micro_Credit.Helpers;
using CRM_Micro_Credit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Security.Claims;

namespace CRM_Micro_Credit.Controllers
{
    [Authorize(Policy = "Users")]
    public class InfoCreditController : Controller
    {
		private DataContext dataContext { get; set; }
        private string logPath { get; set; }
        private IQueryable<Education> educations { get; set; }
        private IQueryable<Work> works { get; set; }
		private IQueryable<Agreement> agreements { get; set; }

		public InfoCreditController([FromServices] DataContext dataContext, IOptions<Settings> settings)
        {
            logPath= settings.Value.LogPath;

            this.dataContext = dataContext;

			educations = dataContext.Educations;

			works = dataContext.Works;

            agreements = dataContext.Agreements;
		}
        public IActionResult Index()
        {
            var phoneNumber = ClaimsHelper.GetClaimValue(User.Claims, nameof(ClaimTypes.MobilePhone).ToLower(), logPath);

            var user = dataContext.Users.FirstOrDefault(x => x.Mobile == phoneNumber) ?? new User();

            return View(new InfoCreditPageModel() { User = user, Educations = educations.ToList(), Works = works.ToList(), Agreements = agreements.ToList() });
        }

        [HttpPost]
        public async Task<IActionResult> Index(InfoCreditPageModel InfoCreditPage, List<string> agreement)
        {
			InfoCreditPage.User.Mobile = ClaimsHelper.GetClaimValue(User.Claims, nameof(ClaimTypes.MobilePhone).ToLower(), logPath);

            dataContext.Users.Add(InfoCreditPage.User);

            await dataContext.SaveChangesAsync();

			return View(InfoCreditPage);
        }

    }
}
