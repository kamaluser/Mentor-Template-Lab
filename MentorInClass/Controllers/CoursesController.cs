using MentorInClass.DAL;
using MentorInClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorInClass.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Course> courses = _context.Courses.Include(x=>x.Trainer).ToList();
            return View(courses);
        }
    }
}
