using MentorInClass.DAL;
using MentorInClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorInClass.Controllers
{
    public class TrainerController : Controller
    {
        private readonly AppDbContext _context;

        public TrainerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Trainer> trainers = _context.Trainers.Include(x=>x.Courses).ToList();
            return View(trainers);
        }
    }
}
