using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;

namespace MyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        public _DefaultExperienceComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
