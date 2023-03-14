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
    public class InfoCreditController : Controller
    {
		protected DataContext dataContext { get; set; }
        protected string logPath { get; set; }
        protected IQueryable<Education> educations { get; set; }
        protected IQueryable<Work> works { get; set; }
        protected IQueryable<Agreement> agreements { get; set; }
        protected IQueryable<UserAgreement> userAgreements { get; set; }
        protected IQueryable<User> users { get; set; }

        public InfoCreditController([FromServices] DataContext dataContext, IOptions<Settings> settings)
        {
            logPath= settings.Value.LogPath;

            this.dataContext = dataContext;

			educations = dataContext.Educations;

			works = dataContext.Works;

            agreements = dataContext.Agreements;

            userAgreements = dataContext.UserAgreements;

            users = dataContext.Users;
        }
        public IActionResult Index()
        {
            var phoneNumber = ClaimsHelper.GetClaimValue(User.Claims, nameof(ClaimTypes.MobilePhone).ToLower(), logPath);

            var user = users.FirstOrDefault(x => x.Mobile == phoneNumber) ?? new User();

            var pageName = $"{nameof(InfoCreditController)[..^10]}/{nameof(InfoCreditController.Index)}";

            var agreementsForPage = agreements.Where(x => x.PageNames.Contains(pageName)).ToList();

            List<Agreement> newListAgreements = new List<Agreement>();

            foreach (var item in agreementsForPage)
            {
                var userAgreement = userAgreements.FirstOrDefault(x => (x.UserId == user.Id) && (x.AgreementId == item.Id));

                if (userAgreement == null)
                {
                    newListAgreements.Add(item);
                }
            }

            return View(new InfoCreditPageModel() { User = user, Educations = educations.ToList(), Works = works.ToList(), Agreements = newListAgreements });
        }


        [HttpPost]
        public async Task<IActionResult> Index(InfoCreditPageModel InfoCreditPage, List<string> agreement)
        {
            var phoneNumber = ClaimsHelper.GetClaimValue(User.Claims, nameof(ClaimTypes.MobilePhone).ToLower(), logPath);

            var user = users.FirstOrDefault(x => x.Mobile == phoneNumber) ?? new User();

            InfoCreditPage.User.Mobile = phoneNumber;

            if (user == null)
            {
                dataContext.Users.Add(InfoCreditPage.User);

				await dataContext.SaveChangesAsync();
			}
            else
            {
                InfoCreditPage.User.Id = user.Id;

                dataContext.Entry(user).CurrentValues.SetValues(InfoCreditPage.User);

                await dataContext.SaveChangesAsync();
            }

            foreach (var item in agreement)
            {
                var userAgreement = new UserAgreement
                {
                    UserId = user.Id,
                    AgreementId = agreements.First(x => x.Name == item).Id,
                    PageName = $"{nameof(InfoCreditController)[..^10]}/{nameof(InfoCreditController.Index)}"
                };

				dataContext.UserAgreements.Add(userAgreement);
			}

            InfoCreditPage.Agreements ??= new List<Agreement>();

            if (InfoCreditPage.Agreements.Count != agreement.Count)
			{
				ViewData["ErrorMessage"] = "Подтвердите согласие";
			}
            else
            {
                InfoCreditPage.Agreements = new List<Agreement>();

                await dataContext.SaveChangesAsync();
            }

			return View(InfoCreditPage);
        }

    }
}
