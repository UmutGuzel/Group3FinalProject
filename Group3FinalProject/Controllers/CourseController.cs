using Microsoft.AspNetCore.Mvc;

namespace Group3FinalProject.Controllers
{
	public class CourseController : Controller
	{
		public IActionResult Courses()
		{
			return View();
		}
		public IActionResult CoursesDetails()
		{
			return View();
		}
		public IActionResult Portfolio()
		{
			return View();
		}
	}
}
