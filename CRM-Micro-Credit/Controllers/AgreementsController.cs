using Microsoft.AspNetCore.Mvc;

namespace CRM_Micro_Credit.Controllers
{
	public class AgreementsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Index(string Name)
		{
			return View();
		}
	}
}
