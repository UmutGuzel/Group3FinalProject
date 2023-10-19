using Group3FinalProject.Data;
using Group3FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Group3FinalProject.Controllers
{
	[Authorize(Roles = "Admin,Instructor")]
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

		public async Task<IActionResult> Courses()
		{
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<Course> courses;
            if (await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(id), "Admin"))
            {
                courses = _context.Courses.Include(c => c.Category).ToList<Course>();
            }
            else
            {
                courses = _context.Courses.Include(c => c.Category).Where(x => id == x.UserId).ToList<Course>();
            }
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
		
		public async Task<IActionResult> EditUser(string id)
		{
            var user = _context.Users.Select(
                x => new GiveRoleOutput
                {
                    UserId = x.Id,
                    Email = x.Email,
                    UserName = x.UserName
                }
            ).First();
            var roles = _context.Roles.ToList();
            var userRoles = _context.UserRoles.ToList();
            foreach (var role in userRoles)
            {
                if (role.UserId.Equals(user.UserId))
                {
                    user.RoleId = role.RoleId;
                    break;
                }
            }
            foreach (var role in roles)
            {
                if (role.Id.Equals(user.RoleId))
                {
                    user.Role = role.Name;
                    break;
                }
            }
                ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
            return View(user);
		}

        [HttpPost]
        public async Task<IActionResult> EditUser(GiveRoleOutput giveRoleOutput)
        {
            Console.WriteLine(giveRoleOutput.UserName);
            return RedirectToAction("GiveRole");
        }

    }

}
