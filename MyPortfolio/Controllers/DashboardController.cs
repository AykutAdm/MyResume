using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;
using System.Linq;

namespace MyPortfolio.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyPortfolioContext _context;

        public DashboardController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Mesaj İstatistikleri
            ViewBag.TotalMessage = _context.Messages.Count();
            ViewBag.UnreadMessage = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.ReadMessage = _context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.LastMessageSender = _context.Messages.OrderByDescending(x => x.SendDate).Select(y => y.NameSurname).FirstOrDefault() ?? "Henüz mesaj yok";

            // Diğer İstatistikler
            ViewBag.TotalPortfolio = _context.Portfolios.Count();
            ViewBag.TotalService = _context.Services.Count();
            ViewBag.TotalSkill = _context.Skills.Count();
            ViewBag.TotalExperience = _context.Experiences.Count();
            ViewBag.TotalTestimonial = _context.Testimonials.Count();
            ViewBag.TotalCategory = _context.Categories.Count();
            ViewBag.TotalEducation = _context.Educations.Count();
            ViewBag.TotalFeature = _context.Features.Count();

            return View();
        }
    }
}
