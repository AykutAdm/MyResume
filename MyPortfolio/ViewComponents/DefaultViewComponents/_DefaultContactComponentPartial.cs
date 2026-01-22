using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;
using MyPortfolio.Entities;

namespace MyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        public _DefaultContactComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }
    }
}
