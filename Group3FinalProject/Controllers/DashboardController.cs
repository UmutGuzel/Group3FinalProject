using Group3FinalProject.Data;
using Group3FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group3FinalProject.Controllers
{
	public class DashboardController : Controller
	{
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Courses()
		{
			List<Course> courses= _context.Courses.ToList<Course>();
			return View(courses);
		}
		public IActionResult TeacherProfile()
		{
			return View();
		}

	}
}
