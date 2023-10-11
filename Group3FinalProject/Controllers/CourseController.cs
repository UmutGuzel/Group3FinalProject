using Microsoft.AspNetCore.Mvc;

namespace Group3FinalProject.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
