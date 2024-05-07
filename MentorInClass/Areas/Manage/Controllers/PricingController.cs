using MentorInClass.Areas.Manage.ViewModels;
using MentorInClass.DAL;
using MentorInClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace MentorInClass.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;

        public PricingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            return View(PaginatedList<Card>.Create(_context.Cards.Include(x=>x.CardFeatures),page,2));
        }

        public IActionResult Create()
        {
            ViewBag.Features = _context.Features;
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Card card)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Features = _context.Features;
                return View(card);
            }
            if(_context.Cards.Any(x=>x.Name == card.Name))
            {
                ModelState.AddModelError("Name", "Name Already Exists!");
                return View(card);
            }

            foreach(var featureId in card.FeatureIds)
            {
                if (!_context.Features.Any(x => x.Id == featureId)) return RedirectToAction("notfound", "error");
                CardFeature cardFeature = new CardFeature
                {
                    FeatureId = featureId,
                    Card = card
                };
                _context.cardFeatures.Add(cardFeature);
            }

            _context.Cards.Add(card);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Card card = _context.Cards.Include(x => x.CardFeatures).FirstOrDefault(x => x.Id == id);
            if (card == null)
            {
                return RedirectToAction("notfound", "error");
            }
            ViewBag.FeatureIds = card.FeatureIds;
            ViewBag.Features = _context.Features;
            return View(card);
        }

        [HttpPost]
        public IActionResult Edit(Card card)
        {
            Card? existCard = _context.Cards.Include(x=>x.CardFeatures).FirstOrDefault(x=>x.Id == card.Id);

            if (existCard == null) return RedirectToAction("notfound", "error");

            existCard.Name = card.Name;
            existCard.BtnContext = card.BtnContext;
            existCard.IsAdvanced = card.IsAdvanced;
            existCard.IsFeatured = card.IsFeatured;
            existCard.Price = card.Price;


            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
