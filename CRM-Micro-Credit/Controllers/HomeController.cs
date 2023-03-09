using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM_Micro_Credit.Controllers
{
    public class HomeController : Controller
    {
        private DataContext dataContext { get; set; }

        public HomeController([FromServices] DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}