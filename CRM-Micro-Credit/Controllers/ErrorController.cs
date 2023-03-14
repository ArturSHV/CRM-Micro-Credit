using CRM_Micro_Credit.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Micro_Credit.Controllers
{
	public class ErrorController : Controller
	{
		[HttpGet]
		[Route("{controller}/{Code}")]
		public IActionResult Index(int Code)
		{
			var error = new Error(Code);
			return View(new ErrorPageModel() { Error = error });
		}
	}
}
