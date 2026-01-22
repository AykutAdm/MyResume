using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Context;
using MyPortfolio.Entities;

namespace MyPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly MyPortfolioContext _context;

        public PortfolioController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult PortfolioList()
        {
            var values = _context.Portfolios.Include(x => x.Category).ToList();
            return View(values);
        }

        public IActionResult CreatePortfolio()
        {
            List<SelectListItem> categoryvalues = (from x in _context.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categoryvalue = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }


        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            _context.Portfolios.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            List<SelectListItem> categoryvalues = (from x in _context.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categoryvalue = categoryvalues;
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
