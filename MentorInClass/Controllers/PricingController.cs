using MentorInClass.DAL;
using MentorInClass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorInClass.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;

        public PricingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PricingViewModel pricingViewModel = new PricingViewModel()
            {
                Cards = _context.Cards.Include(x=>x.CardFeatures).ToList(),
                Features = _context.Features.Include(x => x.CardFeatures).ToList(),
            };
            return View(pricingViewModel);
        }
    }
}
