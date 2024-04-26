using MentorInClass;
using MentorInClass.DAL;
using MentorInClass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MentorInClass.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
        {
			_context = context;
		}
        public IActionResult Index()
		{
			HomeVM vm = new HomeVM()
			{
				Trainers=_context.Trainers.OrderByDescending(x=>x.Id).Take(3).ToList(),
				Courses=_context.Courses.OrderByDescending(x => x.Id).Take(3).ToList(),
			};
			return View(vm);
		}

	}
}
