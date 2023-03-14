using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Micro_Credit.Controllers
{
	public class AgreementsController : Controller
	{
		private DataContext dataContext { get; set; }
		public AgreementsController([FromServices] DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		[HttpGet]
		[Route("{controller}/{Name}")]
		public IActionResult Index(string Name)
		{
			var url = $"{nameof(AgreementsController)[..^10]}/{Name}";

			var agreement = dataContext.Agreements.FirstOrDefault(x=>x.Url == url);

			if (agreement == null)
				return Redirect($"/{nameof(ErrorController)[..^10]}");

			return View(new AgreementPageModel { Agreement = agreement});
		}
	}
}
