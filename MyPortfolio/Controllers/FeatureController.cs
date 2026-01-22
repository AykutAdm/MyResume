using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;
using MyPortfolio.Entities;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        private readonly MyPortfolioContext _context;

        public FeatureController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeature(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var value = _context.Features.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateFeature(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}
