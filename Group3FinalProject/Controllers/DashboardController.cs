using Group3FinalProject.Data;
using Group3FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Group3FinalProject.Controllers
{
	public class DashboardController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<IdentityUser> userManage)
        {
			_userManager = userManage;
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

        public IActionResult GiveRole()
		{ 
            var users = _context.Users.Select(
				user => new GiveRoleOutput
				{
					UserId = user.Id,
					Email = user.Email,
					UserName = user.UserName
				}
			).ToList();

			var roles = _context.Roles.ToList();
			var userRoles = _context.UserRoles.ToList();
            foreach (var role in userRoles)
            {
                users.Where(user => user.UserId.Contains(role.UserId)).ToList().ForEach(user => user.RoleId = role.RoleId);
            }
            foreach (var role in roles)
            {
                users.Where(user => user.RoleId.Contains(role.Id)).ToList().ForEach(user => user.Role = role.Name);
            }
            return View(users);
        }
		
		public async Task<IActionResult> EditUser(GiveRoleOutput model)
		{

            //var user = await _userManager.FindByIdAsync(id);
            ViewData["RoleId"] = new SelectList(_context.Courses, "CourseId", "Title");
            return View(model);
		}

    }

}
