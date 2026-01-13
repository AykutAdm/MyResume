using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultPortfolioComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
