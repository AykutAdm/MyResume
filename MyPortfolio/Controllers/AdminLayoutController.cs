using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Context;

namespace MyPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}