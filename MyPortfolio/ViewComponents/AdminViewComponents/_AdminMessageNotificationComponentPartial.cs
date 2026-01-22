using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;
using MyPortfolio.Entities;
using System.Linq;

namespace MyPortfolio.ViewComponents.AdminViewComponents
{
    public class _AdminMessageNotificationComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        public _AdminMessageNotificationComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages
                .OrderByDescending(x => x.SendDate)
                .Where(y => y.IsRead == false)
                .Take(3)
                .ToList();
            return View(values);
        }
    }
}

