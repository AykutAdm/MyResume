using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;

namespace MyPortfolio.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly MyPortfolioContext _context;

        public StatisticsController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _context.Messages.Count();
            ViewBag.v2 = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v3 = _context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.v4 = _context.Messages.Where(x => x.MessageId == 1).Select(y => y.NameSurname).FirstOrDefault();
            return View();
        }
    }
}
