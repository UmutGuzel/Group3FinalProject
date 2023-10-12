using Microsoft.AspNetCore.Mvc;

namespace Group3FinalProject.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Courses()
		{
			return View();
		}
		public IActionResult TeacherProfile()
		{
			return View();
		}

	}
}
