using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Context;
using MyPortfolio.Entities;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly MyPortfolioContext _context;

        public SkillController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = _context.Skills.Find(id);
            _context.Skills.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}
