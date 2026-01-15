using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;

namespace MyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultPortfolioComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        public _DefaultPortfolioComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }
    }
}
